using System.ComponentModel.DataAnnotations;

namespace Pustok.Areas.Manage.ViewModels
{
    public class AdminLoginViewModel
    {
        [Required]
        [MaxLength(20)]
        [MinLength(6)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(25)]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
