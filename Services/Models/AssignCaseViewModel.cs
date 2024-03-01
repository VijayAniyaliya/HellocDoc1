using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class AssignCaseViewModel
    {
        public int RequestId { get; set; }
        public List<Region> Regions { get; set; }

        public int PhysicianId { get; set; }
        public string Description { get; set; }
    }
}
