using HellocDoc1.DTO;
using Microsoft.AspNetCore.Mvc;

namespace HellocDoc1.Services
{
    public interface IPatientRequest
    {
        Task Patient_request(PatientRequestModel model);
    }
}