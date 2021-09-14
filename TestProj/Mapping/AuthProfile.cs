using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProj.Application.DTOs;
using TestProj.Models;

namespace TestProj.Mapping
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            CreateMap<UserLoginModel, UserLoginDTO>();

            CreateMap<UserRegisterModel, UserRegisterDTO>();
        }
    }
}
