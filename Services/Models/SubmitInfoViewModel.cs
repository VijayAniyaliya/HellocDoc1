using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace HellocDoc1.Services.Models
{
    public class SubmitInfoViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
        public string RelationWithPatient { get; set; }

        public string Symptoms { get; set; }

        public DateTime DOB { get; set; }


        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        [RegularExpression(@"^[0-9]{6}|[0-9]{5}(?:[-\s][0-9]{4})?$", ErrorMessage = "ZipCode Format is Invalid")]
        public string ZipCode { get; set; }

        public int Room { get; set; }

        public IFormFile Doc { get; set; }
    }
}
