using System.ComponentModel.DataAnnotations;

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

        [StringLength(maximumLength: 100)]
        public string Image { get; set; }
        public double SalePrice { get; set; }
        public double CostPrice { get; set; }
        public double DiscountPercent { get; set; }
        public Category Category { get; set; }
        public Author Author { get; set; }
    }
}
