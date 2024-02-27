using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class ViewCaseViewModel
    {
        public string PatientNotes { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public DateTime DOB { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Region { get; set; }

        public string Address { get; set; }

        public string Room { get; set; }

        public int RequestTypeId { get; set; }

        public int Status { get; set; }
    }
}
