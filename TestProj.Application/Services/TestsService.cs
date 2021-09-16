using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProj.Application.DTOs;
using TestProj.Application.Exceptions;
using TestProj.Application.Services.Contracts;
using TestProj.DataAccess;
using TestProj.DataAccess.Entities;

namespace TestProj.Application.Services
{
    public class TestsService : ITestsService
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public TestsService(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public async Task<IReadOnlyCollection<TestSummaryDTO>> GetUserTestsSummary(string userName)
        {
            UserTest[] tests = await _databaseContext.UserTests
                .AsNoTracking()
                .Include(userTest => userTest.User)
                .Include(userTest => userTest.Test)
                .Where(userTest => userTest.User.Login == userName)
                .ToArrayAsync();

            return _mapper.Map<IEnumerable<Test>, IReadOnlyCollection<TestSummaryDTO>>(tests.Select(userTest => userTest.Test));
        }

        public async Task<TestSummaryDTO> GetTestSummary(int testId)
        {
            Test test = await _databaseContext.Tests
                .AsNoTracking()
                .Include(test => test.Questions)
                .FirstOrDefaultAsync(test => test.Id == testId);

            if (test == null)
            {
                throw new NotFoundException($"Test with id '{testId}' doesn't exists.");
            }

            return _mapper.Map<Test, TestSummaryDTO>(test);
        }

        public async Task<int> StartTest(int userId, int testId)
        {
            if (!await _databaseContext.Users.AnyAsync(user => user.Id == userId))
            {
                throw new NotFoundException($"User with id '{userId}' doesn't exists.");
            }

            Test test = await _databaseContext.Tests
                .AsNoTracking()
                .Include(test => test.Questions)
                .SingleOrDefaultAsync(test => test.Id == testId);

            if (test == null)
            {
                throw new NotFoundException($"Test with id '{testId}' doesn't exists.");
            }

            test.Questions = test.Questions.OrderBy(test => test.Position).ToArray();

            UserTestSession alreadyStartedSession = await _databaseContext.UserTestSessions
                .SingleOrDefaultAsync(session => session.UserId == userId &&
                                                 session.TestId == testId);

            if (alreadyStartedSession != null)
            {
                alreadyStartedSession.CurrentScore = 0;
                alreadyStartedSession.CurrentQuestionId = test.Questions.First().Id;
                alreadyStartedSession.StartedAt = DateTime.Now;

                await _databaseContext.SaveChangesAsync();

                return alreadyStartedSession.CurrentQuestionId;
            }

            var newSession = new UserTestSession()
            {
                CurrentQuestionId = test.Questions.First().Id,
                CurrentScore = 0,
                StartedAt = DateTime.Now,
                TestId = test.Id,
                UserId = userId
            };

            _databaseContext.UserTestSessions.Add(newSession);
            await _databaseContext.SaveChangesAsync();

            return newSession.CurrentQuestionId;
        }

        public async Task<QuestionItemDTO> GetTestQuestion(int questionId)
        {
            Question question = await _databaseContext.Questions
                .AsNoTracking()
                .Include(question => question.Answers)
                .SingleOrDefaultAsync(question => question.Id == questionId);

            if (question == null)
            {
                throw new NotFoundException($"Question with id '{questionId}' doesn't exists.");
            }

            return new QuestionItemDTO()
            {
                Question = _mapper.Map<Question, QuestionDTO>(question),
                CurrentNumber = question.Position,
                TotalCount = _databaseContext.Questions.Count(entity => entity.TestId == question.TestId)
            };
        }

        public async Task<bool> CheckIfUserHasAccess(int userId, int questionId)
        {
            if (!await _databaseContext.UserTests
                .AnyAsync(userTest => userTest.UserId == userId &&
                                      userTest.Test.Questions.Any(question => question.Id == questionId)))
            {
                return false;
            }


            return await _databaseContext.UserTestSessions
                .AsNoTracking()
                .AnyAsync(session => session.UserId == userId &&
                                             session.CurrentQuestionId == questionId);
        }

        public async Task<SubmitAnswerResultDTO> SubmitAnswer(int userId, int questionId, int[] answerIds)
        {
            Question currentQuestion = await _databaseContext.Questions
                .Include(question => question.Test)
                    .ThenInclude(test => test.Questions)
                .Include(question => question.Answers)
                .SingleOrDefaultAsync(question => question.Id == questionId);

            Test currentTest = currentQuestion.Test;

            Answer[] currentAnswers = null;

            if (currentQuestion.Type == QuestionType.One)
            {
                currentAnswers = new Answer[]
                {
                    currentQuestion.Answers.SingleOrDefault(answer => answer.Id == answerIds.First())
                };
            }
            else if (currentQuestion.Type == QuestionType.Multiple)
            {
                currentAnswers = currentQuestion.Answers
                    .Where(answer => answerIds.Contains(answer.Id))
                    .ToArray();
            }
            else
            {
                throw new ArgumentException("Value was not expected.", nameof(currentQuestion.Type));
            }

            UserTestSession currentSession = await _databaseContext.UserTestSessions
                .SingleOrDefaultAsync(session => session.UserId == userId &&
                                                 session.TestId == currentAnswers.First().Question.TestId);

            var result = new SubmitAnswerResultDTO();

            if (currentAnswers.Any(answer => answer.QuestionId != currentSession.CurrentQuestionId))
            {
                throw new UnauthorizedAccessException("One or more answers is not related to the current user question.");
            }

            if (currentQuestion.Type == QuestionType.One)
            {
                if (currentAnswers.First().IsCorrect)
                {
                    currentSession.CurrentScore += currentQuestion.Score;
                }
            }
            else if (currentQuestion.Type == QuestionType.Multiple)
            {
                if (currentAnswers.All(answer => answer.IsCorrect))
                {
                    currentSession.CurrentScore += currentQuestion.Score;
                }
            }

            Question nextQuestion = currentTest.Questions
                .SingleOrDefault(question => question.Position == currentQuestion.Position + 1);

            if (nextQuestion != null)
            {
                currentSession.CurrentQuestionId = nextQuestion.Id;

                result.NextQuestionId = currentSession.CurrentQuestionId;
                result.TestFinished = false;

                await _databaseContext.SaveChangesAsync();
            }
            else
            {
                int maxScore = currentTest.Questions.Sum(question => question.Score);
                float score = ((float)currentSession.CurrentScore / maxScore) * 100;

                var testResult = new UserTestResult
                {
                    CompletionTime = DateTime.Now,
                    Score = score,
                    IsPassed = score >= currentTest.PercentageToPass,
                    TestId = currentTest.Id,
                    UserId = userId,
                };

                _databaseContext.UserTestSessions.Remove(currentSession);
                _databaseContext.UserTestResults.Add(testResult);
                await _databaseContext.SaveChangesAsync();

                result.NextQuestionId = null;
                result.TestFinished = true;
                result.TestResultId = testResult.Id;
            }

            return result;
        }

        public async Task<UserTestResultDTO> GetTestResult(int id)
        {
            UserTestResult result = await _databaseContext.UserTestResults
                .AsNoTracking()
                .Include(result => result.Test)
                .SingleOrDefaultAsync(result => result.Id == id);

            if (result == null)
            {
                throw new NotFoundException($"Can't find test result with id '{id}'.");
            }

            return _mapper.Map<UserTestResult, UserTestResultDTO>(result);
        }
    }
}
