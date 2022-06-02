using Pustok.Models;
using System.Collections.Generic;

namespace Pustok.ViewModels
{
    public class ShopViewModel
    {
        public List<Book> Books { get; set; }
        public List<Category> Categories { get; set; }
    }
}
