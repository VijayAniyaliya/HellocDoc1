using Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class CancelCaseViewModel
    {
        public List<CaseTagViewModel>? ReasonForCancel { get; set; }

        public string? Name { get; set; }

        public int? RequestId { get; set; }
        public string? CaseTag { get; set; }
        public string? AdditionalNotes { get; set; }
    }
}
