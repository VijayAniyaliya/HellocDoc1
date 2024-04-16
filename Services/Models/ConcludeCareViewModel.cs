using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class ConcludeCareViewModel
    {
        public string PatientName { get; set; }

        public int RequestId { get; set; }

        public int IsFinalize { get; set; }

        public string ProviderNotes { get; set; }

        public List<string> Documents= new List<string>();

        public IEnumerable<IFormFile> Upload { get; set; }

    }
}
