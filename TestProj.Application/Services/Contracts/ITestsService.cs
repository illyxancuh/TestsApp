using System.Collections.Generic;
using System.Threading.Tasks;
using TestProj.Application.DTOs;

namespace TestProj.Application.Services.Contracts
{
    public interface ITestsService
    {
        public Task<IReadOnlyCollection<TestSummaryDTO>> GetUserTestsSummary(string userName);
        public Task<TestSummaryDTO> GetTestSummary(int testId);
        public Task<int> StartTest(int userId, int testId);
        public Task<QuestionItemDTO> GetTestQuestion(int questionId);
        public Task<bool> CheckIfUserHasAccess(int userId, int questionId);
        public Task<SubmitAnswerResultDTO> SubmitAnswer(int userId, int questionId, int[] answerIds);
        public Task<UserTestResultDTO> GetTestResult(int id);
    }
}
