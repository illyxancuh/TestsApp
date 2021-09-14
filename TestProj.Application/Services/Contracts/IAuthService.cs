using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProj.Application.DTOs;

namespace TestProj.Application.Services.Contracts
{
    public interface IAuthService
    {
        Task<AuthResultDTO> RegisterUser(UserRegisterDTO userRegisterDTO);

        Task<AuthResultDTO> LoginUser(UserLoginDTO userLoginDTO);

        Task Logout();
    }
}
