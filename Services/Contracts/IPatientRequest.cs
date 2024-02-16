using HellocDoc1.Services.Models;

namespace Services.Contracts
{
    public interface IPatientRequest
    {
        Task Patient_request(PatientRequestModel model);
    }
}