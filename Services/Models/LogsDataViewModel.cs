using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class LogsDataViewModel
    {
        public List<EmailLog> EmailLogs { get; set; }

        public List<Smslog> SmsLogs { get; set; }

        public int RoleId { get; set; }

        public string ReceiverName { get; set; }
        public string? Email { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime SentDate { get; set;}

        public string? PhoneNumber { get; set; }
        public int CurrentPage { get; set; }
        public int requestedPage { get; set; }

        public int TotalPage { get; set; }
    }
}
