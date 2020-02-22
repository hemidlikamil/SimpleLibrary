using System.ComponentModel.DataAnnotations;

namespace SimpleLibrary.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public int? Age { get; set; }

        [Required]
        public double? Salary { get; set; }
    }
}