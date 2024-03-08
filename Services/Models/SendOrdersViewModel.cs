using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class SendOrdersViewModel
    {

        public List<HealthProfession> HealthProfessions { get; set; } = new List<HealthProfession>();

        public List<BusinessType> Business { get; set; } = new List<BusinessType>();

        public string Prescription { get; set; }

        public int? Refills { get; set; }

        public int RequestId { get; set; }


    }

    public class HealthProfession
    {
        public int ProfessionId { get; set; }

        public String ProfessionName { get; set; }

    }
    public class BusinessType
    {
        public int BusinessId { get; set; }

        public String BusinessName { get; set; }

        public String Contact { get; set; }

        public String Email { get; set; }

        public string? FaxNumber { get; set; }


    }
}
