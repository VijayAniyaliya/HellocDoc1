using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public  class ViewNotesViewModel
    {
        public List<TransferNote>? TransferNotes { get; set; }
        public string? PhysicianNotes { get; set; }

        public string? AdminNotes { get; set; }


        public int RequestId { get; set; }
    }   

    public class AddNotesViewModel
    {
        public int RequestId { get; set; }
        public string AdditionalNotes { get; set; }

    }

    public class TransferNote
    {
        public string Notes { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
