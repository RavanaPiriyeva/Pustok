using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.DAL;
using Pustok.ViewModels;
using System.Linq;

namespace Pustok.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;

        public ShopController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ShopViewModel shopVM = new ShopViewModel
            {
                Books = _context.Books.Include(x => x.Category).ToList(),
                Categories = _context.Categories.ToList()
            };

            return View(shopVM);
        }
    }
}
