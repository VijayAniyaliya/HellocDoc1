using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class PatientHistoryViewModel
    {
        public List<User>? Users { get; set; }
        public List<RequestClient> requestClients { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int CurrentPage { get; set; }
        public int requestedPage { get; set; }

        public int TotalPage { get; set; }
    }
}