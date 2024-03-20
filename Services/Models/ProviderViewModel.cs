using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class ProviderViewModel
    {
        public List<PhysicianData>? Physicians { get; set; }
    }  
    public class PhysicianData
    {

        public int physicianId { get; set; }

        public string ProviderName { get; set; }

        public string Role { get; set; }

        public string OnCallStatus { get; set; }

        public string Status { get; set; }
    }
}
