using System.ComponentModel.DataAnnotations;

namespace HellocDoc1.Services.Models
{
    public class ConciergeRequestModel
    {
        [Required(ErrorMessage = "First name is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Enter Valid First Name")]

        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Enter Valid Last Name")]

        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [RegularExpression(@"^[+]?[0-9]*$", ErrorMessage = "Phone number should contain only numbers")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number must be 10 digits")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Property Name is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Enter Valid Property Name")]

        public string PropertyName { get; set; }

        [Required(ErrorMessage = "Street is required")]
        [RegularExpression(@"^(?=.*[a-zA-Z])[a-zA-Z0-9, ]+$", ErrorMessage = "Enter Valid Street")]

        public string Street { get; set; }

        [Required(ErrorMessage = "City is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Enter Valid Street")]

        public string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        public int State { get; set; }

        [Required(ErrorMessage = "ZipCode is required")]

        [RegularExpression(@"^[0-9]{6}|[0-9]{5}(?:[-\s][0-9]{4})?$", ErrorMessage = "ZipCode Format is Invalid")]
        public string ZipCode { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Enter Valid Symptoms")]
        public string? Symptoms { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Enter Valid first Name")]
        public string PatientFirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Enter Valid Last Name")]
        public string PatientLastName { get; set; }

        [Required(ErrorMessage = "DOB is required")]
        public DateTime PatientDOB { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string PatientEmail { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [RegularExpression(@"^[+]?[0-9]*$", ErrorMessage = "Phone number should contain only numbers")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number must be 10 digits")]
        public string PatientPhoneNumber { get; set; }

        [RegularExpression(@"^[+]?[0-9]*$", ErrorMessage = "Room number should contain only numbers")]
        [StringLength(5, MinimumLength = 1, ErrorMessage = "Enter Valid Room Number")]
        public int? PatientRoom { get; set; }
    }
}
