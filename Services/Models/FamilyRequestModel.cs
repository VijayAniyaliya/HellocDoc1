using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace HellocDoc1.Services.Models
{
    public class FamilyRequestModel
    {
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Enter Valid First Name")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "First Name leangth must be more then 2 and less then 20 character")]

        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Enter Valid Last Name")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Last Name leangth must be more then 2 and less then 20 character")]

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [RegularExpression(@"^[+]?[0-9]*$", ErrorMessage = "Phone number should contain only numbers")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number must be 10 digits")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Relation With Patient is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Enter Valid Relation")]
        public string RelationWithPatient { get; set; }

        public string? Symptoms { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "First Name leangth must be more then 2 and less then 20 character")]

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Enter Valid First Name")]
        public string PatientFirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Last Name leangth must be more then 2 and less then 20 character")]

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

        public int? PatientRoom { get; set; }

        public IEnumerable<IFormFile>? Doc { get; set; }
    }
}
