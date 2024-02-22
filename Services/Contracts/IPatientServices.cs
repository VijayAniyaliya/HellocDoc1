using Data.Entity;
using HellocDoc1.Services.Models;
using Services.Models;

namespace Services.Contracts
{
    public interface IPatientServices
    {
        void ChangePassword(string email, ChangePassViewModel model);

        List<Request> DashboardService(string Email);

        PatientServiceModel DocumentService(int Requestid);

        Task<byte[]> DownloadFilesForRequest(int request_id);

        void Editing(string Email, User model);

        User ProfileService(string Email);

        void ResetPassword(string email);

        void SubmitInformationSomeone(SubmitInfoViewModel model);
        void UploadDocument(PatientServiceModel model, int request_id);
    }
}