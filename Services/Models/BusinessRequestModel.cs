using System.ComponentModel.DataAnnotations;

namespace HellocDoc1.Services.Models
{
    public class BusinessRequestModel
    {
        [Required(ErrorMessage = "First name is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Enter Valid First Name")]

        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Enter Valid Last Name")]

        public string LastName { get; set; }

        [Required(ErrorMessage = "PhoneNumber is required")]
        [RegularExpression(@"^[+]?[0-9]*$", ErrorMessage = "Phone number should contain only numbers")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number must be 10 digits")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Propert name is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Enter Valid Property Name")]

        public string PropertyName { get; set; }
        [RegularExpression(@"^[+]?[0-9]*$", ErrorMessage = "Case number should contain only numbers")]

        [StringLength(5, MinimumLength = 1, ErrorMessage = "Enter Valid Case Number")]

        public string? CaseNumber { get; set; }

        [RegularExpression(@"^(?=.*[a-zA-Z])[a-zA-Z\s]+$", ErrorMessage = "Enter Valid Symptoms")]

        public string? Symptoms { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Enter Valid First Name")]

        public string PatientFirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Enter Valid Last Name")]

        public string PatientLastName { get; set; }

        [Required(ErrorMessage = "DOB is required")]
        public DateTime PatientDOB { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string PatientEmail { get; set; }

        [Required(ErrorMessage = "PhoneNumber is required")]
        [RegularExpression(@"^[+]?[0-9]*$", ErrorMessage = "Phone number should contain only numbers")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number must be 10 digits")]
        public string PatientPhoneNumber { get; set; }

        [Required(ErrorMessage = "Street is required")]
        [RegularExpression(@"^(?=.*[a-zA-Z])[a-zA-Z0-9, ]+$", ErrorMessage = "Enter Valid Street")]

        public string PatientStreet { get; set; }

        [Required(ErrorMessage = "City is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Enter Valid City")]

        public string PatientCity { get; set; }

        [Required(ErrorMessage = "State is required")]
        public int PatientState { get; set; }

        [Required(ErrorMessage = "ZipCode is required")]

        [RegularExpression(@"^[0-9]{6}|[0-9]{5}(?:[-\s][0-9]{4})?$", ErrorMessage = "ZipCode Format is Invalid")]
        public string PatientZipCode { get; set; }
        [RegularExpression(@"^[+]?[0-9]*$", ErrorMessage = "Room number should contain only numbers")]

        [StringLength(5, MinimumLength = 1, ErrorMessage = "Enter Valid Room Number")]
        public int? PatientRoom { get; set; }
    }
}
