using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.DAL;
using Pustok.Models;
using System.Linq;

namespace Pustok.Controllers
{
    public class BookController : Controller
    {
        private readonly AppDbContext _context;

        public BookController(AppDbContext context)
        {
            _context = context;
        }
        

        public IActionResult GetBookModal(int id)
        {
            Book book = _context.Books.Include(x => x.Category).Include(x => x.Author).Include(x => x.BookImages).FirstOrDefault(x => x.Id == id);

            if (book == null)
                return NotFound();

            return PartialView("_BookModalPartial", book);
        }
    }
}
