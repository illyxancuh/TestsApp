using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestProj.Application.DTOs;
using TestProj.Application.Services.Contracts;
using TestProj.Models;

namespace TestProj.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;

        public AccountController(IMapper mapper, IAuthService authService)
        {
            _mapper = mapper;
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegisterModel userRegisterModel)
        {
            if (ModelState.IsValid)
            {
                UserRegisterDTO userRegisterDTO = _mapper.Map<UserRegisterModel, UserRegisterDTO>(userRegisterModel);
                AuthResultDTO result = await _authService.RegisterUser(userRegisterDTO);
                if (result.Success)
                {
                    return Content("Registered");// ЗАГЛУШКА СУКА ТУТ НЕ ЗАБУДЬ
                }
                foreach (string error in result.Errors)
                {
                    ModelState.AddModelError(null, error);
                }
            }
            return View(userRegisterModel);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginModel userLoginModel)
        {
            if (ModelState.IsValid)
            {
                UserLoginDTO userLoginDTO = _mapper.Map<UserLoginModel, UserLoginDTO>(userLoginModel);
                AuthResultDTO result = await _authService.LoginUser(userLoginDTO);
                if (result.Success)
                {
                    return Content("Logined");// ЗАГЛУШКА СУКА ТУТ НЕ ЗАБУДЬ
                }
                foreach (string error in result.Errors)
                {
                    ModelState.AddModelError(null, error);
                }
            }
            return View(userLoginModel);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _authService.Logout();

            return RedirectToAction("Login", "Account");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
