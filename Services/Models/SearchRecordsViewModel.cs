using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class SearchRecordsViewModel
    {
        public List<RequestClient> requestClients { get; set; }

        public int RequestStatus { get; set; }
        public string PatientName { get; set; }
        public int RequestType { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string ProviderName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int CurrentPage { get; set; }
        public int requestedPage { get; set; }
        public int TotalPage { get; set; }
    }
}
