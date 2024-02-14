using HellocDoc1.DataModels;

namespace HellocDoc1.DTO
{
    public class PatientServiceModel
    {
        public Request request {  get; set; }
        public List<RequestWiseFile> requestWiseFile { get; set; }
        public RequestClient requestClient { get; set; }

    }
}
