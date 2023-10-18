using System.ComponentModel.DataAnnotations;

namespace SchoolDummy.Models
{
    public class RegisterModel
    {
        [Required]
        [StringLength(100)]
        [Display(Name ="User name")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter password!")]
        [StringLength(100)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }
    }
}
