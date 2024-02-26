using Data.Entity;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace HellocDoc1.Services.Models
{
    public class PatientServiceModel
    {
        public Request request {  get; set; }
        public List<RequestWiseFile> requestWiseFile { get; set; }
        public RequestClient requestClient { get; set; }

        [Required(ErrorMessage = "Please Select Document")]
        public IEnumerable<IFormFile> Doc { get; set; }

    }
}
