using System.ComponentModel.DataAnnotations;

namespace Pustok.Models
{
    public class Book
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        [StringLength(maximumLength: 25)]
        public string Name { get; set; }
        [StringLength(maximumLength: 30)]
        public string Author { get; set; }
        [StringLength(maximumLength: 250)]
        public string Desc { get; set; }

        [StringLength(maximumLength: 100)]
        public string Image { get; set; }
        public Category Category { get; set; }
    }
}
