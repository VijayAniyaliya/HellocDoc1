using System.ComponentModel.DataAnnotations;

namespace HellocDoc1.Services.Models
{
    public class BusinessRequestModel
    {
        [Required(ErrorMessage = "First name is required")] 
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "PhoneNumber is required")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Propert name is required")]
        public string PropertyName { get; set; }

        public string CaseNumber { get; set; }

        public string Symptoms { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string PatientFirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string PatientLastName { get; set; }

        [Required(ErrorMessage = "DOB is required")]
        public DateTime PatientDOB { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string PatientEmail { get; set; }

        [Required(ErrorMessage = "PhoneNumber is required")]
        public string PatientPhoneNumber { get; set; }

        [Required(ErrorMessage = "Street is required")]
        public string PatientStreet { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string PatientCity { get; set; }

        [Required(ErrorMessage = "State is required")]
        public string PatientState { get; set; }

        [Required(ErrorMessage = "ZipCode is required")]

        [RegularExpression(@"^[0-9]{6}|[0-9]{5}(?:[-\s][0-9]{4})?$", ErrorMessage = "ZipCode Format is Invalid")]
        public string PatientZipCode { get; set; }

        public int PatientRoom { get; set; }
    }
}
