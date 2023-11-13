using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MutfakUygulamasiMVC.Data.Entity;
using MutfakUygulamasiMVC.Models;

namespace MutfakUygulamasiMVC.Controllers
{

    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel userLoginViewModel)
        {
            AppUser appUser = await _userManager.FindByEmailAsync(userLoginViewModel.Email);
            var signInAsync = _signInManager.PasswordSignInAsync(appUser, userLoginViewModel.Password, false, false);
            if (signInAsync.Result.Succeeded)
                return RedirectToAction("Index", "Home");
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterViewModel registerViewModel)
        {
            AppUser appUser = new AppUser()
            {
                Email = registerViewModel.Email,
                UserName = registerViewModel.Email
            };
            var result = await _userManager.CreateAsync(appUser, registerViewModel.Password);
            if (result.Succeeded)
                RedirectToAction("Login", "User");
            return View(registerViewModel);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
