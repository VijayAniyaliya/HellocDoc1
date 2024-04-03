using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class SchedullingViewModel
    {
        public List<Region>? RegionList { get; set; }

        public List<Physician>? physicians { get; set; }

        public List<ShiftDetail> ShiftDetailList { get; set; }

        public DateTime ShiftDate { get; set; }
    }
}