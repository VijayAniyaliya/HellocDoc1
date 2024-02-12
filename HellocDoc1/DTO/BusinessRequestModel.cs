using System.ComponentModel.DataAnnotations;

namespace HellocDoc1.DTO
{
    public class BusinessRequestModel
    {
        [Required(ErrorMessage = "First name is required")] 
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string PropertyName { get; set; }

        public string CaseNumber { get; set; }

        public string Symptoms { get; set; }

        public string PatientFirstName { get; set; }

        public string PatientLastName { get; set; }

        public DateTime PatientDOB { get; set; }

        public string PatientEmail { get; set; }

        public string PatientPhoneNumber { get; set; }

        public string PatientStreet { get; set; }

        public string PatientCity { get; set; }

        public string PatientState { get; set; }

        public string PatientZipCode { get; set; }

        public int PatientRoom { get; set; }
    }
}
