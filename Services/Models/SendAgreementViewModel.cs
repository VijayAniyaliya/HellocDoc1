using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class SendAgreementViewModel
    {
        public string PatientName { get; set; }
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public int RequestId { get; set; }

         public int RequestTypeId { get; set; }

        public string ReasonForCancel { get; set; }

    }
}
