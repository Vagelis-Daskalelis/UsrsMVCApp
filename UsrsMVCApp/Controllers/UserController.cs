using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UsrsMVCApp.DTO;
using UsrsMVCApp.Models;
using UsrsMVCApp.Services;

namespace UsrsMVCApp.Controllers
{
    public class UserController : Controller
    {
        public List<Error>? ErrorArray { get; set; }
        private readonly IMapper _mapper;
        private readonly IApplicationService? _applicationService;

        public UserController(List<Error>? errorArray, IMapper mapper, IApplicationService? applicationService)
        {
            ErrorArray = errorArray;
            _mapper = mapper;
            _applicationService = applicationService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            ClaimsPrincipal principal = HttpContext.User;
            if (principal.Identity!.IsAuthenticated) 
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp([FromForm]UserSignUpDTO userSignUpDTO)
        {
            if (!ModelState.IsValid)
            {
                foreach (var entry in ModelState.Values)
                {
                    foreach (var error in entry.Errors)
                    {
                        ErrorArray!.Add(new Error("", error.ErrorMessage, ""));
                    }
                }
                ViewData["ErrorArray"] = ErrorArray;
                return View(); //return with errors
            }

            try
            {

                await _applicationService!.UserService!.SignUpUserAsync(userSignUpDTO);
            }
            catch (Exception e)
            {

                ErrorArray!.Add(new Error("", e.Message, ""));
                ViewData["ErrorAray"] = ErrorArray;
                return View(); //return with errors
            }

            return View(); //return without errors
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDTO credentials)
        {
            var user = await _applicationService!.UserService!.LoginUserAsync(credentials);
            if (user is null) 
            {
                ViewData["ValidateMessage"] = "Erro. Username / Password invalid";
                return View(); // with errors
            }

            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.NameIdentifier, credentials!.Username!),
                //new Claim(ClaimTypes.Role, user.Role!)
            };

            ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            AuthenticationProperties properties = new()
            {
                AllowRefresh = true,
                IsPersistent = credentials.KeepLoggedIn
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), properties);
            return RedirectToAction("Index", "Home");
        }
    }
}
