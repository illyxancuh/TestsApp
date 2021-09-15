using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TestProj.DataAccess;
using TestProj.DataAccess.Entities;
using TestProj.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using TestProj.Application.Services.Contracts;
using AutoMapper;
using TestProj.Application.DTOs;

namespace TestProj.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITestsService _testsService;
        private readonly IMapper _mapper;

        private readonly DatabaseContext _databaseContext;

        public HomeController(ILogger<HomeController> logger, ITestsService testsService, IMapper mapper,
            DatabaseContext databaseContext)
        {
            _logger = logger;
            _testsService = testsService;
            _mapper = mapper;

            _databaseContext = databaseContext;
        }

        public async Task<IActionResult> Index()
        {
            if(User.Identity.IsAuthenticated)
            {
                var userTestsDTOs = await _testsService.GetUserTestsSummary(User.Identity.Name);
                var userTestsModels = _mapper.Map<IReadOnlyCollection<TestSummaryDTO>, IReadOnlyCollection<TestSummaryModel>>(userTestsDTOs);

                return View(userTestsModels);
            }

            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public async Task<IActionResult> Generate()
        {
            Test testTest = new Test
            {
                Description = "krot ebal kota, kot ebal gusya. A guse ohuel i dal vsem pizdi. Etim gusem bil Albert Enstein.",
                Name = "Kto ebal gusya?",
                ImageUrl = "https://cdn.igromania.ru/mnt/articles/6/b/8/d/f/8/31014/preview/4cf560741d18c651_1920xH.jpg",
                Questions = new Question[]
                {
                    new Question
                    {
                        QuestionText = "Kto ebal kota?",
                        Score = 2,
                        Type = QuestionType.One,
                        Answers = new Answer[]
                        {
                            new Answer()
                            {
                                AnswerText = "Kot",
                                IsCorrect = false
                            },
                            new Answer()
                            {
                                AnswerText = "Vova",
                                IsCorrect = false
                            },
                            new Answer()
                            {
                                AnswerText = "Krot",
                                IsCorrect = true
                            }
                        }
                    },
                    new Question
                    {
                        QuestionText = "Kak zvali gusya?",
                        Score = 5,
                        Type = QuestionType.Multiple,
                        Answers = new Answer[]
                        {
                            new Answer()
                            {
                                AnswerText = "Albert",
                                IsCorrect = true
                            },
                            new Answer()
                            {
                                AnswerText = "Albert Enstein",
                                IsCorrect = true
                            },
                            new Answer()
                            {
                                AnswerText = "Xui Gorinich",
                                IsCorrect = false
                            }
                        }
                    }
                }
            };

            _databaseContext.UpdateUserTests(User.Identity.Name, new[] { testTest });

            _databaseContext.Add(testTest);

            return Ok("ok");
        }

        public async Task<IActionResult> Privacy()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
