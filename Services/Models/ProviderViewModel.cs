using Data.Entity;
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

        public List<Region> Regions { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
    }  
    public class PhysicianData
    {
        public int? region { get; set; }

        public List<PhysicianNotification> PhysicianNotifications { get; set; }
        public string role { get; set; }


        public int physicianId { get; set; }            

        public string ProviderName { get; set; }

        public string Role { get; set; }

        public string OnCallStatus { get; set; }

        public int Status { get; set; }
    }
}
