using Pustok.DAL;
using Pustok.Models;
using System.Collections.Generic;
using System.Linq;

namespace Pustok.Services
{
    public class LayoutService
    {
        private readonly AppDbContext _context;

        public LayoutService(AppDbContext context)
        {
            _context = context;
        }

        public List<Category> GetGenres()
        {
            return _context.Categories.ToList();
        }

        public Dictionary<string, string> GetSettings()
        {
            return _context.Settings.ToDictionary(x => x.Key, y => y.Value);
        }
    }
}
