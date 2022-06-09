using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.DAL;
using Pustok.Helpers;
using Pustok.Models;
using System.Collections.Generic;
using System.Linq;

namespace Pustok.Areas.Manage.Controllers
{
    [Area("manage")]
    public class BookController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly AppDbContext _context;

        public BookController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Book> books = _context.Books.Include(x => x.Category).Include(x => x.Author).ToList();
            return View(books);
        }
        public IActionResult Create()
        {
            ViewBag.Authors = _context.Authors.ToList();
            ViewBag.Genres = _context.Categories.ToList();

            return View();
        }
        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Authors = _context.Authors.ToList();
                ViewBag.Genres = _context.Categories.ToList();
                return View();
            }


            if (!_context.Authors.Any(x => x.Id == book.AuthorId))
            {
                ModelState.AddModelError("AuthorId", "Author notfound");
                ViewBag.Authors = _context.Authors.ToList();
                ViewBag.Genres = _context.Categories.ToList();

                return View();
            }

            if (!_context.Categories.Any(x => x.Id == book.CategoryId))
            {
                ModelState.AddModelError("GenreId", "Genre notfound");
                ViewBag.Authors = _context.Authors.ToList();
                ViewBag.Genres = _context.Categories.ToList();

                return View();
            }

            if (book.PosterFile == null)
            {
                ModelState.AddModelError("PosterFile", "PosterFile is required");
                ViewBag.Authors = _context.Authors.ToList();
                ViewBag.Genres = _context.Categories.ToList();
                return View();
            }
            else
            {

                if (book.PosterFile.ContentType != "image/png" && book.PosterFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("PosterFile", "File format must be image/png or image/jpeg");
                }

                if (book.PosterFile.Length > 2097152)
                {
                    ModelState.AddModelError("PosterFile", "File size must be less than 2MB");
                }

                if (!ModelState.IsValid)
                {
                    ViewBag.Authors = _context.Authors.ToList();
                    ViewBag.Genres = _context.Categories.ToList();
                    return View();
                }

                BookImage bookImage = new BookImage
                {
                    Name = FileManager.Save(_env.WebRootPath, "upload/book", book.PosterFile),
                    PosterStatus = true
                };

                book.BookImages.Add(bookImage);
            }



            if (book.ImageFiles != null)
            {
                foreach (var file in book.ImageFiles)
                {
                    if (file.ContentType != "image/png" && file.ContentType != "image/jpeg")
                    {
                        ModelState.AddModelError("ImageFiles", "File format must be image/png or image/jpeg");
                    }

                    if (file.Length > 2097152)
                    {
                        ModelState.AddModelError("ImageFiles", "File size must be less than 2MB");
                    }

                    if (!ModelState.IsValid)
                    {
                        ViewBag.Authors = _context.Authors.ToList();
                        ViewBag.Genres = _context.Categories.ToList();
                        return View();
                    }
                }

                foreach (var file in book.ImageFiles)
                {
                    BookImage bookImage = new BookImage
                    {
                        Name = FileManager.Save(_env.WebRootPath, "upload/book", file),
                        PosterStatus = null
                    };

                    book.BookImages.Add(bookImage);
                }
            }



            _context.Books.Add(book);
            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}
