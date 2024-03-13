using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public  class CloseCaseViewModel
    {
        public string PatientName { get; set; }

        public string ConfirmationNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DOB { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public int RequestId { get; set; }

        public List<DocumentDetails> Documents { get; set; } = new List<DocumentDetails>();

    }
    public class DocumentDetails
    {
        public int DocumentId { get; set; }

        public String Document { get; set; }

        public String UploadDate { get; set; }
    }
}
