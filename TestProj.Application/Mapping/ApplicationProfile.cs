using AutoMapper;
using TestProj.Application.DTOs;
using TestProj.DataAccess.Entities;

namespace TestProj.Application.Mapping
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Test, TestSummaryDTO>()
                .ForMember(dto => dto.QuestionsCount, expression => expression.MapFrom(test => test.Questions.Count));

            CreateMap<QuestionType, QuestionTypeDTO>();
            CreateMap<Question, QuestionDTO>();
            CreateMap<Answer, AnswerDTO>();

            CreateMap<UserTestResult, UserTestResultDTO>()
                .ForMember(dto => dto.TestSummary, expression => expression.MapFrom(test => test.Test));
        }
    }
}
