using System.ComponentModel.DataAnnotations;

namespace WebApplication10.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Email Is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Password Is Required")]
        [MinLength(8, ErrorMessage = "Invalid Password")]
        public string Password { get; set; }
    }
}
