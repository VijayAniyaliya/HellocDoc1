using Services.Models;

namespace Services.Contracts
{
    public interface IProviderServices
    {
        Task AcceptCase(int request_id);
        Task<AdminDashboardViewModel> ActiveState(AdminDashboardViewModel obj, string email);
        Task AddNotes(ViewNotesViewModel model, int request_id, string email);
        Task<ConcludeCareViewModel> ConcludeCare(int request_id);
        Task<AdminDashboardViewModel> ConcludeState(AdminDashboardViewModel obj, string email);
        Task Consult(int request_id);
        Task<AdminDashboardViewModel> NewState(AdminDashboardViewModel obj, string email);
        Task<AdminDashboardViewModel> PendingState(AdminDashboardViewModel obj, string email);
        Task<AdminDashboardViewModel> ProviderDashboard(string email);
        Task TransferCaseToAdmin(int request_id, string reason, string email);
        Task UploadDocuments(ConcludeCareViewModel model, int request_id);
    }
}