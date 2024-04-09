using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public  class RequestedShiftViewModel
    {
        public List<Region>? RegionList { get; set; }
        public List<ShiftDetail>? ShiftDetailList { get; set; }

        public int region {  get; set; }
        public int CurrentPage { get; set; }
        public int requestedPage { get; set; }

        public int TotalPage { get; set; }
    }
}
