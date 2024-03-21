﻿using Data.Entity;
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
        public List<PhysicianNotification> PhysicianNotifications { get; set; }

        public int physicianId { get; set; }

        public string ProviderName { get; set; }

        public string Role { get; set; }

        public string OnCallStatus { get; set; }

        public int Status { get; set; }
    }
}
