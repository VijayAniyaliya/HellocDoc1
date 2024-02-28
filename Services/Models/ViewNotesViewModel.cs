using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public  class ViewNotesViewModel
    {
        public string? TransferNotes { get; set; }
        public string? PhysicianNotes { get; set; }

        public string? AdminNotes { get; set; }
        public string AdditionalNotes { get; set; }

        public int RequestId { get; set; }
    }
}
