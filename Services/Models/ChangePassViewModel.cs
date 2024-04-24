using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class ChangePassViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "The password must contain at least one uppercase, one lowercase letter, one digit, one special character, and be at least 8 characters long.")]

        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "The password and confirm password must be same.")]
        public string ConfirmPassword { get; set; }
    }
}
