using System.ComponentModel.DataAnnotations;

namespace SimpleLibrary.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "User Name")]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        [MaxLength(30)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [MaxLength(30)]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}