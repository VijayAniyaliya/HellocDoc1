using Data.Entity;
using Microsoft.AspNetCore.Http;

namespace HellocDoc1.Services.Models
{
    public class PatientServiceModel
    {
        public Request request {  get; set; }
        public List<RequestWiseFile> requestWiseFile { get; set; }
        public RequestClient requestClient { get; set; }

        public IEnumerable<IFormFile> Doc { get; set; }

    }
}
