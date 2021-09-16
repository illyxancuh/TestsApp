using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using TestProj.Application.DTOs;
using TestProj.Application.Services.Contracts;
using TestProj.Models;

namespace TestProj.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITestsService _testsService;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, ITestsService testsService, IMapper mapper)
        {
            _logger = logger;
            _testsService = testsService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userTestsDTOs = await _testsService.GetUserTestsSummary(User.Identity.Name);
                var userTestsModels = _mapper.Map<IReadOnlyCollection<TestSummaryDTO>, IReadOnlyCollection<TestSummaryModel>>(userTestsDTOs);

                return View(userTestsModels);
            }

            return RedirectToAction("Login", "Account");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
