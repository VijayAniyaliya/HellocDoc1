using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace HellocDoc1.Services.Models
{
    public class SubmitInfoViewModel
    {
        [Required(ErrorMessage = "First name is required")]

        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]

        public string LastName { get; set; }
        [Required(ErrorMessage = "Phone Number is required")]

        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email is required")]

        public string Email { get; set; }
        [Required(ErrorMessage = "Relation With Patient is required")]

        public string RelationWithPatient { get; set; }


        public string? Symptoms { get; set; }
        [Required(ErrorMessage = "Date Of Birth is required")]

        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Streetis required")]

        public string Street { get; set; }
        [Required(ErrorMessage = "Cityis required")]

        public string City { get; set; }
        [Required(ErrorMessage = "State is required")]

        public string State { get; set; }
        [Required(ErrorMessage = "ZipCode is required")]

        [RegularExpression(@"^[0-9]{6}|[0-9]{5}(?:[-\s][0-9]{4})?$", ErrorMessage = "ZipCode Format is Invalid")]
        public string ZipCode { get; set; }

        public int? Room { get; set; }

        public IFormFile Doc { get; set; }
    }
}
