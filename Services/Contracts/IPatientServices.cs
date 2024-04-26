using Data.Entity;
using HellocDoc1.Services.Models;
using Services.Models;

namespace Services.Contracts
{
    public interface IPatientServices
    {
        Task ChangePassword(string email, ChangePassViewModel model);

        Task<PatientDashboardViewModel> DashboardData(int requestedPage, string email);

        Task<PatientServiceModel> DocumentService(int Requestid);

        Task<byte[]> DownloadFilesForRequest(int request_id);

        Task Editing(string Email, ProfileViewModel model);

        Task<ProfileViewModel> ProfileService(string Email);

        Task<LoginResponseViewModel> ResetPassword(LoginViewModel model);

        Task SubmitInformationSomeone(SubmitInfoViewModel model);
        Task UploadDocument(PatientServiceModel model, int request_id);

        Task<SendAgreementViewModel> ReviewAgreement(string request_id);

        Task AcceptAgreement(int request_id);
        Task CancelAgreement(int request_id, string reason);
        Task<User> CheckEmail(string email);
        Task<PatientRequestModel> SubmitInformationMe(string email);
    }
}