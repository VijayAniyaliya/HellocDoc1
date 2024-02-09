namespace HellocDoc1.DTO
{
    public class FamilyRequestModel
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string RelationWithPatient { get; set; }

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

        public IFormFile Doc { get; set; }
    }
}
