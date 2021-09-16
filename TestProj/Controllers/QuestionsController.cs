using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TestProj.Application.DTOs;
using TestProj.Application.Services.Contracts;
using TestProj.Models;

namespace TestProj.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITestsService _testsService;

        public QuestionsController(IMapper mapper, ITestsService testsService)
        {
            _mapper = mapper;
            _testsService = testsService;
        }

        [HttpGet("{controller}/{questionId}")]
        public async Task<IActionResult> GetQuestion(int questionId)
        {
            int userId = int.Parse(User.FindFirst("Id").Value);

            if (!await _testsService.CheckIfUserHasAccess(userId, questionId))
            {
                throw new UnauthorizedAccessException("User has no access to related test.");
            }

            var questionItemDTO = await _testsService.GetTestQuestion(questionId);
            var questionItemModel = _mapper.Map<QuestionItemDTO, QuestionItemModel>(questionItemDTO);

            return View("QuestionPassage", questionItemModel);
        }

        [HttpPost("{controller}/{questionId}/submit")]
        public async Task<IActionResult> SubmitAnswer([FromRoute] int questionId, [FromBody] int[] answerIds)
        {
            int userId = int.Parse(User.FindFirst("Id").Value);

            if (answerIds == null || answerIds.Length == 0)
            {
                return BadRequest("Answers was not provided.");
            }

            SubmitAnswerResultDTO submitResult = 
                await _testsService.SubmitAnswer(userId, questionId, answerIds);

            return Ok(new { sumbitResult = submitResult });
        }
    }
}
