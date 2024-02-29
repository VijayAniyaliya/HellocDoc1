using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class CancelCaseViewModel
    {
        public  List<CaseTag>? ReasonForCancel { get; set; }
        public string? AdditionalNotes { get; set; }
    }
}
