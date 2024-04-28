using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace HellocDoc1.Services.Models
{
    public class PatientRequestModel
    {
        public string? Symptoms { get; set; }   
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Enter Valid First Name")]
        [Required(ErrorMessage = "First name is required")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "First Name leangth must be more then 2 and less then 20 character")]

        public string FirstName { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Enter Valid Last Name")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Last Name leangth must be more then 2 and less then 20 character")]

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "DOB is required")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "The password must contain at least one uppercase, one lowercase letter, one digit, one special character, and be at least 8 characters long.")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "The password and confirm password must be same.")]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone Number is required")]
        [RegularExpression(@"^[+]?[0-9]*$", ErrorMessage = "Phone number should contain only numbers")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number must be 10 digits")]
        public string PhoneNumber { get; set; }


        [Required(ErrorMessage = "Street is required")]
        [RegularExpression(@"^(?=.*[a-zA-Z])[a-zA-Z0-9, ]+$", ErrorMessage = "Enter Valid Street")]

        public string Street { get; set; }

        [Required(ErrorMessage = " City name is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Enter Valid City")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        public int State { get; set; }
            
        [Required(ErrorMessage = "ZipCode is required")]
        [RegularExpression(@"^[0-9]{6}|[0-9]{5}(?:[-\s][0-9]{4})?$", ErrorMessage = "ZipCode Format is Invalid")]
        public string ZipCode { get; set; }

        public int? Room { get; set; }

        public IEnumerable<IFormFile>? Doc { get; set; }


    }
}
