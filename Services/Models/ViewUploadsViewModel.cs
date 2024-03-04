using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class ViewUploadsViewModel
    {
        public String Name { get; set; }

        public int RequestId { get; set; }
        public String ConfirmationNo { get; set; }

        public IEnumerable<IFormFile> Upload { get; set; }
        public List<DocumentDetail> Documents { get; set; } = new List<DocumentDetail>();

    }

    public class DocumentDetail
    {
        public int DocumentId { get; set; }

        public String Document { get; set; }

        public String UploadDate { get; set; }
    }
}
