using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpGet("{controller}/{testId}/summary")]
        public async Task<IActionResult> TestSummary(int testId)
        {
            var testSummaryDTO = await _testsService.GetTestSummary(testId);
            var testSummaryModel = _mapper.Map<TestSummaryDTO, TestSummaryModel>(testSummaryDTO);

            return View(testSummaryModel);
        }

        [HttpPost("{controller}/{testId}/start")]
        public async Task<IActionResult> StartTest(int testId)
        {
            int userId = int.Parse(User.FindFirst("Id").Value);
            int firstQuestionId = await _testsService.StartTest(userId, testId);

            return Ok(new { questionId = firstQuestionId });
        }

        [HttpGet("{controller}/results/{testResultsId}")]
        public async Task<IActionResult> Results(int testResultsId)
        {
            UserTestResultDTO result = await _testsService.GetTestResult(testResultsId);
            if(result.UserId != int.Parse(User.FindFirst("Id").Value))
            {
                throw new UnauthorizedAccessException("Result is not related to the current user.");
            }

            return View(_mapper.Map<UserTestResultDTO, TestPassedModel>(result));
        }
    }
}
