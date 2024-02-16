using Data.Entity;

namespace HellocDoc1.Services.Models
{
    public class PatientServiceModel
    {
        public Request request {  get; set; }
        public List<RequestWiseFile> requestWiseFile { get; set; }
        public RequestClient requestClient { get; set; }

    }
}
