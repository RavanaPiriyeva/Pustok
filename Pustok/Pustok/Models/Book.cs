using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pustok.Models
{
    public class Book
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        [StringLength(maximumLength: 25)]
        public string Name { get; set; }
        
        public int AuthorId { get; set; }
        [StringLength(maximumLength: 250)]
        public string Desc { get; set; }
        public bool IsAvailable { get; set; }
        public byte Rate { get; set; }
        public bool IsNew { get; set; }
        public bool IsFeatured { get; set; }
        [StringLength(maximumLength: 100)]
        public string Image { get; set; }
        public double SalePrice { get; set; }
        public double CostPrice { get; set; }
        public double DiscountPercent { get; set; }
        public Category Category { get; set; }
        public Author Author { get; set; }
        public List<BookImage> BookImages { get; set; } = new List<BookImage>();

        [NotMapped]
        public IFormFile PosterFile { get; set; }

        [NotMapped]
        public List<IFormFile> ImageFiles { get; set; }
    }
}
