using System.ComponentModel.DataAnnotations;

namespace Pustok.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 25)]
        public string Name { get; set; }

        
    }
}
