using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Services.Models
{   
    public class CreateRequestViewModel
    {
        public string? Notes { get; set; }

        [Required (ErrorMessage ="First name is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Enter Valid Symptoms")]

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
        [Required(ErrorMessage = "DOB is required")]
        public DateTime DOB { get; set; }



        [Required(ErrorMessage = "Street is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Enter Valid Street")]

        public string Street { get; set; }

        [Required(ErrorMessage = " City name is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Enter Valid City")]

        public string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }

        [Required(ErrorMessage = "ZipCode is required")]
        [RegularExpression(@"^[0-9]{6}|[0-9]{5}(?:[-\s][0-9]{4})?$", ErrorMessage = "ZipCode Format is Invalid")]
        public string ZipCode { get; set; }

        public int? Room { get; set; }


    }
}
