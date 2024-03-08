using Data.Entity;
using HellocDoc1.Services.Models;
using Services.Models;

namespace Services.Contracts
{
    public interface IAdminServices
    {
        AdminDashboardViewModel NewState(int CurrentPage, int PageSize = 10);

        AdminDashboardViewModel AdminDashboard();
        List<RequestClient> PendingState();
        List<RequestClient> ActiveState();
        List<RequestClient> ConcludeState();
        List<RequestClient> ToCloseState();
        List<RequestClient> UnpaidState();
        ViewCaseViewModel  ViewCase(int request_id);
        ViewNotesViewModel ViewNotes(int request_id);
        void AddNotes(ViewNotesViewModel model, int request_id);
        CancelCaseViewModel CancelDetails(int request_id);
        Task CancelCase(CancelCaseViewModel model, int request_id);
        BlockCaseViewModel BlockDetails(int request_id);
        Task BlockCase(BlockCaseViewModel model, int request_id);
        AssignCaseViewModel AssignDetails(int request_id);
        List<PhysicianSelectlViewModel> FilterData(int regionid);
        Task AssignCase(AssignCaseViewModel model, int request_id);
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
        Task TransferCase(TransferCaseViewModel model, int request_id);
        ClearCaseViewModel ClearDetails(int request_id);
        Task ClearCase(ClearCaseViewModel model, int request_id);
    }
}