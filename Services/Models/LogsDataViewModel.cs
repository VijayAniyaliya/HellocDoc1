using Data.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class LogsDataViewModel
    {
        public List<Role> Roles { get; set; }
        public List<LogsData> logsDatas { get; set; }

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

    public class LogsData
    {
        public int RoleId { get; set; }

        public string RoleName { get; set; }
        public string ReceiverName { get; set; }
        public string Action { get; set; }
        public string ConfirmationNo { get; set; }
        public string? Email { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime SentDate { get; set; }
        public BitArray IsEmailSent { get; set; }
        public int SentTries { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
