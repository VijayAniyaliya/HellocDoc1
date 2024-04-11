using Data.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class BlockHistoryViewModel
    {
        public List<BlockRequest> blockRequests {  get; set; }

        public List<RequestClient> requestClients { get; set; }
        public string? Name { get; set; }

        public DateTime Date { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int CurrentPage { get; set; }
        public int requestedPage { get; set; }

        public int TotalPage { get; set; }
    }

    public class blockdata
    {
        public string PatientName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Notes { get; set; }

        public BitArray IsActive { get; set; }
    }
}
