using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class VendorsDetailsViewModel
    {
        public List<HealthProfessionalType>? healthProfessionalTypes { get; set; }

        public List<VendorsData> vendorsDatas { get; set; }

    }

    public class VendorsData
    {
        public int ProfessionId { get; set; }
        public string Profession { get; set; }
        public string VendorName { get; set; }
        public string Email { get; set; }
        public string FaxNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string BusinessContact { get; set; }
    }
}