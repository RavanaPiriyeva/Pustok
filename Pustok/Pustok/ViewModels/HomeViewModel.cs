using Pustok.Models;
using System.Collections.Generic;

namespace Pustok.ViewModels
{
    public class HomeViewModel
    {
       
            public List<Slider> Sliders { get; set; }
            public List<Feature> Features { get; set; }
        public List<Book> DiscountedBooks { get; set; }
        public List<Book> FeaturedBooks { get; set; }
        public List<Book> NewBooks { get; set; }


    }
}
