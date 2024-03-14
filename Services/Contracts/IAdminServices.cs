using Data.Entity;
using HellocDoc1.Services.Models;
using Services.Models;

namespace Services.Contracts
{
    public interface IAdminServices
    {
        AdminDashboardViewModel NewState(int CurrentPage, string patientname = "", int requesttype = 5 , int PageSize = 10);

        AdminDashboardViewModel AdminDashboard();
        AdminDashboardViewModel PendingState(int CurrentPage = 1, string patientname = "", int requesttype = 5, int PageSize = 10);
        AdminDashboardViewModel ActiveState(int CurrentPage = 1, string patientname = "", int requesttype = 5, int PageSize = 10);
        AdminDashboardViewModel ConcludeState(int CurrentPage = 1, string patientname = "", int requesttype = 5, int PageSize = 10);
        AdminDashboardViewModel ToCloseState(int CurrentPage , string patientname , int requesttype , int PageSize);
        AdminDashboardViewModel UnpaidState(int CurrentPage = 1, string patientname = "", int requesttype = 5, int PageSize = 10);
        ViewCaseViewModel  ViewCase(int request_id);
        ViewNotesViewModel ViewNotes(int request_id);
        void AddNotes(ViewNotesViewModel model, int request_id);
        CancelCaseViewModel CancelDetails(int request_id);
        Task CancelCase(int request_id, int caseId, string cancelNote);
        BlockCaseViewModel BlockDetails(int request_id);
        Task BlockCase(int request_id, string reason);
        AssignCaseViewModel AssignDetails(int request_id);
        List<PhysicianSelectlViewModel> FilterData(int regionid);
        Task AssignCase(int request_id, int physicianid, string description);
        ViewUploadsViewModel ViewUploads(int request_id);
        void UploadDocuments(ViewUploadsViewModel model, int request_id);
        void Delete(int DocumentId);
        void DeleteAll(List<int> DocumentId);
        void SendMail(List<int> DocumentId);
        LoginResponseViewModel AdminLogin(AdminLoginViewModel model);
        SendOrdersViewModel SendOders(int request_id);
        SendOrdersViewModel FilterDataByProfession(int ProfessionId);
        SendOrdersViewModel FilterDataByBusiness(int BusinessId);
        Task SendOrderDetails(SendOrdersViewModel model, int request_id, int vendorid, string contact, string email, string faxnumber);
        TransferCaseViewModel TransferDetails(int request_id);
        Task TransferCase(int request_id, int physicianid, string description);
        ClearCaseViewModel ClearDetails(int request_id);
        Task ClearCase(ClearCaseViewModel model, int request_id);
        SendAgreementViewModel SendAgreementDetails(int request_id);
        void SendAgreement(SendAgreementViewModel model, int request_id);
        CloseCaseViewModel CloseCase(int request_id);
        Task SaveCloseCase(CloseCaseViewModel model, int request_id);
        Task CloseCaseRequest(int request_id);
        EncounterFormViewModel EncounterForm(int request_id);
        Task SubmitEncounterForm(EncounterFormViewModel model, int request_id);
    }
}