namespace HellocDoc1.DTO
{
    public class PatientRequestModel
    {
        public string Symptoms { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public DateTime DOB { get; set; }
        
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public int Room { get; set; }

        public IFormFile Doc { get; set; }


    }
}
