using System.ComponentModel.DataAnnotations;

namespace HellocDoc1.Services.Models
{
    public class ConciergeRequestModel
    {
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Property Name is required")]
        public string PropertyName { get; set; }

        [Required(ErrorMessage = "Street is required")]
        public string Street { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }

        [Required(ErrorMessage = "ZipCode is required")]
        public string ZipCode { get; set; }

        public string Symptoms { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string PatientFirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string PatientLastName { get; set; }

        [Required(ErrorMessage = "DOB is required")]
        public DateTime PatientDOB { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string PatientEmail { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        public string PatientPhoneNumber { get; set; }

        public int PatientRoom { get; set; }
    }
}
