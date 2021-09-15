using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestProj.Application.DTOs;
using TestProj.Application.Services.Contracts;
using TestProj.Models;

namespace TestProj.Controllers
{
    [Authorize]
    public class TestsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITestsService _testsService;

        public TestsController(IMapper mapper, ITestsService testsService)
        {
            _mapper = mapper;
            _testsService = testsService;
        }

        [HttpGet("{testId}")]
        public async Task<IActionResult> TestSummary(string testId)
        {
            var testSummaryDTO = await _testsService.GetUserTestSummary(User.Identity.Name, testId);
            var testSummaryModel = _mapper.Map<TestSummaryDTO, TestSummaryModel>(testSummaryDTO);

            return View(testSummaryModel);
        }
    }
}
