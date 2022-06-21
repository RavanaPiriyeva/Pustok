using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.Models;
using Pustok.ViewModels;
using System.Threading.Tasks;

namespace Pustok.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            AccountIndexViewModel vm = new AccountIndexViewModel
            {
                LoginVM = new MemberLoginViewModel(),
                RegisterVM = new MemberRegisterViewModel()
            };
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Register(MemberRegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("index", new AccountIndexViewModel { RegisterVM = registerViewModel });
            }
            AppUser appUser = new AppUser
            {
                FullName = registerViewModel.FullName,
                Email = registerViewModel.Email,
                UserName = registerViewModel.RegisterUserName,
                IsAdmin = false
        };
            var result = await _userManager.CreateAsync(appUser, registerViewModel.RegisterPassword);
            if (!result.Succeeded)
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Code);
                }
                return View("index");
            }
            string token = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);

            var url = Url.Action("ConfirmEmail", "Account", new { email = appUser.Email, token = token }, Request.Scheme);

            await _userManager.AddToRoleAsync(appUser, "Member");

            return Ok(new { URL = url });

            return RedirectToAction("index");

        }
        [HttpPost]
        public async Task<IActionResult> Login(MemberLoginViewModel memberVM)
        {
            if (!ModelState.IsValid)
                return View("index", new AccountIndexViewModel { LoginVM = memberVM, RegisterVM = new MemberRegisterViewModel() });

            AppUser member = await _userManager.Users.FirstOrDefaultAsync(x => !x.IsAdmin && x.UserName == memberVM.LoginUserName);

            if (member == null)
            {
                ModelState.AddModelError("", "UserName or Password is incorrect");
                return View("index", new AccountIndexViewModel { LoginVM = memberVM, RegisterVM = new MemberRegisterViewModel() });
            }

            var result = await _signInManager.PasswordSignInAsync(member, memberVM.LoginPassword, false, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "UserName or Password is incorrect");
                return View("index", new AccountIndexViewModel { LoginVM = memberVM, RegisterVM = new MemberRegisterViewModel() });
            }

            return RedirectToAction("index", "home");
        }

        public async Task<IActionResult> Logout()

        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }
        public IActionResult Forgot()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult > Forgot (MemberForgetPassworViewModel foretVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser appUser = await _userManager.FindByEmailAsync(foretVM.Email);
            if(appUser == null)
            {
                ModelState.AddModelError("Email", "Email movcud deyil!!!");
                return View();
            }

            string token =await _userManager.GeneratePasswordResetTokenAsync(appUser);
            var url = Url.Action("ResetPassword", "Account", new { email = appUser.Email, token = token }, Request.Scheme);

            return Ok(new { URL = url });
        }
        public async Task<IActionResult> ConfirmEmail(string email ,string token)
        {
            AppUser appUser = await _userManager.FindByEmailAsync(email);
            if(appUser == null)
            {
                return RedirectToAction("error", "dashboard");
            }
            var result = await _userManager.ConfirmEmailAsync(appUser, token);
            if (!result.Succeeded)
            {
                return RedirectToAction("error", "dashboard");
            }
            return RedirectToAction("index");
        }

        public async Task<IActionResult> ResetPassword(string email, string token)
        {
            AppUser member = await _userManager.Users.FirstOrDefaultAsync(x => !x.IsAdmin && x.NormalizedEmail == email.ToUpper());
            if (member == null)
                return RedirectToAction("error", "dashboard");

            if (!await _userManager.VerifyUserTokenAsync(member, _userManager.Options.Tokens.PasswordResetTokenProvider, "ResetPassword", token))
                return RedirectToAction("error", "dashboard");


            MemberResetPasswodViewModel vm = new MemberResetPasswodViewModel
            {
                Email = email,
                Token = token
            };
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword (MemberResetPasswodViewModel resetVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser appUser = await _userManager.Users.FirstOrDefaultAsync(x => !x.IsAdmin && x.NormalizedEmail == resetVM.Email.ToUpper());
            if (appUser == null)
            {
                return RedirectToAction("error", "dashboard");
            }
            var result = await _userManager.ResetPasswordAsync(appUser, resetVM.Token, resetVM.Password);
            if (!result.Succeeded)
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }
            return RedirectToAction("index");
        }
    }
}
