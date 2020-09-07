using System.ComponentModel.DataAnnotations;

namespace Imip.Models.Authentication
{
    public class LoginModel
    {
        //[Required(ErrorMessage = "User Name is required")]
        //public string Username { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
