using System.ComponentModel.DataAnnotations;

namespace SimpleLibrary.ViewModels
{
    public class LogonViewModel
    {
        [Required]
        [Display(Name = "User Name")]
        [MaxLength(20)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}