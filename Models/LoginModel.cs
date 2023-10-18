using System.ComponentModel.DataAnnotations;

namespace SchoolDummy.Models
{
    public class LoginModel
    {
        [Required]
        [StringLength(100)]
        [Display(Name = "User name")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter password!")]
        [StringLength(100)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
