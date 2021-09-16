using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;
using TestProj.Application.DTOs;
using TestProj.Application.Services.Contracts;
using TestProj.DataAccess;
using TestProj.DataAccess.Entities;

namespace TestProj.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public AuthService(IHttpContextAccessor httpContextAccessor, DatabaseContext databaseContext, IMapper mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public async Task<AuthResultDTO> LoginUser(UserLoginDTO userLoginDTO)
        {
            var existingUser = await _databaseContext.Users
                .AsNoTracking()
                .SingleOrDefaultAsync(user => user.Login == userLoginDTO.Login);

            if (existingUser == null || !BCrypt.Net.BCrypt.Verify(userLoginDTO.Password, existingUser.PasswordHash))
            {
                return new AuthResultDTO
                {
                    Success = false,
                    Errors = new string[] { "Invalid login or password" }
                };
            }

            await Authenticate(existingUser.Login, existingUser.Id);

            return new AuthResultDTO() { Success = true };
        }

        public async Task<AuthResultDTO> RegisterUser(UserRegisterDTO userRegisterDTO)
        {
            var existingUser = await _databaseContext.Users
                .AsNoTracking()
                .SingleOrDefaultAsync(user => user.Login == userRegisterDTO.Login);

            if (existingUser != null)
            {
                return new AuthResultDTO
                {
                    Success = false,
                    Errors = new string[] { "User with this login is already exists" }
                };
            }

            User newUser = _mapper.Map<UserRegisterDTO, User>(userRegisterDTO);

            _databaseContext.Add(newUser);
            await _databaseContext.SaveChangesAsync();

            await Authenticate(newUser.Login, newUser.Id);

            return new AuthResultDTO() { Success = true };
        }

        public async Task Logout()
        {
            await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        private async Task Authenticate(string userName, int userId)
        {
            var claims = new Claim[]
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName),
                new Claim("Id", userId.ToString())
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
        }
    }
}
