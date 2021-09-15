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
        }
    }
}
