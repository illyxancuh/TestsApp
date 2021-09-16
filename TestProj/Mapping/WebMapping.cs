using AutoMapper;
using TestProj.Application.DTOs;
using TestProj.Models;

namespace TestProj.Mapping
{
    public class WebMapping : Profile
    {
        public WebMapping()
        {
            CreateMap<TestSummaryDTO, TestSummaryModel>();

            CreateMap<QuestionTypeDTO, QuestionTypeModel>();

            CreateMap<AnswerDTO, AnswerModel>();

            CreateMap<QuestionDTO, QuestionModel>();

            CreateMap<QuestionItemDTO, QuestionItemModel>();

            CreateMap<UserTestResultDTO, TestPassedModel>();
        }
    }
}
