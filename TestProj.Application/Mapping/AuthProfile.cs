using AutoMapper;
using TestProj.Application.DTOs;
using TestProj.DataAccess.Entities;

namespace TestProj.Application.Mapping
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            CreateMap<UserRegisterDTO, User>()
                .ForMember(user => user.PasswordHash,
                           rule => rule.MapFrom(userRegisterDTO => BCrypt.Net.BCrypt.HashPassword(userRegisterDTO.Password)));
        }
    }
}
