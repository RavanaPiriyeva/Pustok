using System.ComponentModel.DataAnnotations;

namespace Pustok.Areas.Manage.ViewModels
{
    public class AdminRegisterViewModel
    {

        [Required]
        [MaxLength(25)]
        [MinLength(6)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(25)]
        [MinLength(4)]
        public string FullName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        [Required]
        [MaxLength(25)]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [MaxLength(25)]
        [MinLength(8)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    
}
}
