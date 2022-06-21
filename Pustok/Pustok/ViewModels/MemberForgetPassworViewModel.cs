using System.ComponentModel.DataAnnotations;

namespace Pustok.ViewModels
{
    public class MemberForgetPassworViewModel
    {
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
    }
}
