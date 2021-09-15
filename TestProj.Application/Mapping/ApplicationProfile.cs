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
        }
    }
}
