using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TestProj.DataAccess;
using TestProj.DataAccess.Entities;

namespace TestProj.Controllers
{
    public class TempController : Controller
    {
        private DatabaseContext _databaseContext;

        public TempController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [HttpPost("{controller}/addtest")]
        [AllowAnonymous]
        public async Task<IActionResult> AddTest([FromBody] Test newTest, [FromQuery] int userId)
        {
            if (newTest == null)
                return BadRequest("Test was not provided.");

            if (newTest.Questions == null || !newTest.Questions.Any())
                return BadRequest("Questions was not provided.");

            if (newTest.Questions.Any(question => question.Position == 0))
                return BadRequest("Questions should have position greater than 0.");

            if (newTest.Questions.All(question => question.Score <= 0))
                return BadRequest("Questions score should be greater than 0.");

            foreach (Question question in newTest.Questions)
            {
                if (question.Answers.All(answer => !answer.IsCorrect))
                {
                    return BadRequest("Question answers should have at least one correct answer.");
                }
            }

            _databaseContext.Tests.Add(newTest);
            await _databaseContext.SaveChangesAsync();

            _databaseContext.UserTests.Add(new UserTest
            {
                TestId = newTest.Id,
                UserId = userId
            });

            await _databaseContext.SaveChangesAsync();

            return Created("api/addtest", newTest);
        }

        [HttpPost("{controller}/testadd")]
        public async Task<IActionResult> TestAdd()
        {
            Test testTest = new Test
            {
                Description = "C# is a modern, object-oriented, and type-safe programming language. C# enables developers to build many types of secure and robust applications that run in .NET. C# has its roots in the C family of languages and will be immediately familiar to C, C++, Java, and JavaScript programmers. ",
                Name = "C# Test",
                ImageUrl = "https://mobios.school/images/15.08.2018/ccccc.jpg",
                PercentageToPass = 70,
                Questions = new Question[]
                {
                    new Question
                    {
                        QuestionText = "C# is",
                        Score = 1,
                        Type = QuestionType.One,
                        Answers = new Answer[]
                        {
                            new Answer()
                            {
                                AnswerText = "Object-oriented language",
                                IsCorrect = true,
                            },
                            new Answer()
                            {
                                AnswerText = "Structural language",
                                IsCorrect = false
                            },
                            new Answer()
                            {
                                AnswerText = "Functional languge",
                                IsCorrect = false
                            }
                        }
                    },
                    new Question
                    {
                        QuestionText = "Which modifiers are exist?",
                        Score = 1,
                        Type = QuestionType.Multiple,
                        Answers = new Answer[]
                        {
                            new Answer()
                            {
                                AnswerText = "Private",
                                IsCorrect = true
                            },
                            new Answer()
                            {
                                AnswerText = "Public",
                                IsCorrect = true
                            },
                            new Answer()
                            {
                                AnswerText = "Project",
                                IsCorrect = false
                            },
                            new Answer()
                            {
                                AnswerText = "Protected",
                                IsCorrect = true
                            },
                            new Answer()
                            {
                                AnswerText = "Safe",
                                IsCorrect = false
                            },
                            new Answer()
                            {
                                AnswerText = "Internal",
                                IsCorrect = true
                            }
                        }
                    },
                    new Question
                    {
                        QuestionText = "Which data types C# DOESN'T have?",
                        Score = 1,
                        Type = QuestionType.Multiple,
                        Answers = new Answer[]
                        {
                            new Answer()
                            {
                                AnswerText = "Int128",
                                IsCorrect = true
                            },
                            new Answer()
                            {
                                AnswerText = "Boolean",
                                IsCorrect = true
                            },
                            new Answer()
                            {
                                AnswerText = "Bool",
                                IsCorrect = false
                            },
                            new Answer()
                            {
                                AnswerText = "Number",
                                IsCorrect = true
                            },
                            new Answer()
                            {
                                AnswerText = "Float",
                                IsCorrect = false
                            },
                            new Answer()
                            {
                                AnswerText = "Decimal",
                                IsCorrect = false
                            }
                        }
                    },
                    new Question
                    {
                        QuestionText = "Which statement about ASP.NET is wrong?",
                        Score = 1,
                        Type = QuestionType.One,
                        Answers = new Answer[]
                        {
                            new Answer()
                            {
                                AnswerText = "ASP.NET means Active Sever Pages",
                                IsCorrect = false
                            },
                            new Answer()
                            {
                                AnswerText = "ASP.NET has .Core and .Framework versions",
                                IsCorrect = false
                            },
                            new Answer()
                            {
                                AnswerText = "ASP.NET Core can only be launched in Windows",
                                IsCorrect = true
                            }
                        }
                    },
                    new Question
                    {
                        QuestionText = "Is .NET Core open source?",
                        Score = 1,
                        Type = QuestionType.One,
                        Answers = new Answer[]
                        {
                            new Answer()
                            {
                                AnswerText = "Yes",
                                IsCorrect = true
                            },
                            new Answer()
                            {
                                AnswerText = "No",
                                IsCorrect = false
                            }
                        }
                    },
                }
            };

            for (int i = 0; i < testTest.Questions.Count; i++)
            {
                testTest.Questions.ElementAt(i).Position = i+1;
            }
            for (int i = 0; i < testTest.Questions.Count; i++)
            {
                testTest.Questions.ElementAt(i).Score = 1;
            }

            _databaseContext.Tests.Add(testTest);
            await _databaseContext.SaveChangesAsync();

            return Ok("Created id: " + testTest.Id);
        }
    }
}
