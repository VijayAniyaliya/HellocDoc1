using System.ComponentModel.DataAnnotations;

namespace HellocDoc1.Services.Models
{
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
