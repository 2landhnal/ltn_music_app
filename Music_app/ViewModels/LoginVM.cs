using System.ComponentModel.DataAnnotations;

namespace Music_app.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Please enter your username.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter your password.")]
        public string Password { get; set; }
    }
}
