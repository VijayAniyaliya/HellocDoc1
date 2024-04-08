using Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class CreateNewShift
    {
        public List<Region>? RegionList { get; set; }

        public int ShiftDetailId { get; set; }

        [Required(ErrorMessage = "Please Select Region")]
        public int RegionId { get; set; }
        public string? RegionName { get; set; }

        [Required(ErrorMessage = "Please Select Physician")]
        public int PhysicianId { get; set; }
        public string PhysicianName { get; set; }

        [Required(ErrorMessage = "ShiftDate is required")]
        public DateTime ShiftDate { get; set; }

        [Required(ErrorMessage = "StartTime is required")]
        public TimeOnly Start {  get; set; }

        [Required(ErrorMessage = "EndTime is required")]
        public TimeOnly End { get; set; }

        public List<int>? RepeatDays { get; set; }

        public int RepeatEnd {  get; set; }
    }
}
