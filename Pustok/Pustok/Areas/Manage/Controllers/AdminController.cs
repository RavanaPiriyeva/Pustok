using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.Areas.Manage.ViewModels;
using Pustok.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.Areas.Manage.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    [Area("manage")]
  
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AdminController(UserManager<AppUser> userManager,  RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var user =  _userManager.GetUsersInRoleAsync("admin").Result;
            return View(user);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AdminRegisterViewModel admin)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser appUser = new AppUser
            {
                FullName = admin.FullName,
                Email = admin.Email,
                UserName = admin.UserName,
                IsAdmin = true
            };
            var result = await _userManager.CreateAsync(appUser, admin.Password);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Code);
                }
                return View("index");
            }
            await _userManager.AddToRoleAsync(appUser, "Admin");
            return RedirectToAction("index");

        }
        //[HttpPost]
        //public IActionResult Create(Author author)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View();
        //    }

        //    _context.Authors.Add(author);
        //    _context.SaveChanges();

        //    return RedirectToAction("index");
        //}
        public async Task<IActionResult> SweetDelete(string id)

        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

           var result =await _userManager.DeleteAsync(user);

            return RedirectToAction("index");
        }
    }
}
