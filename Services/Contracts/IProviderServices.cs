using Services.Models;

namespace Services.Contracts
{
    public interface IProviderServices
    {
        Task AcceptCase(int request_id);
        Task<AdminDashboardViewModel> ActiveState(AdminDashboardViewModel obj, string email);
        Task AddNotes(ViewNotesViewModel model, int request_id, string email);
        Task<AdminDashboardViewModel> ConcludeState(AdminDashboardViewModel obj, string email);
        Task<AdminDashboardViewModel> NewState(AdminDashboardViewModel obj, string email);
        Task<AdminDashboardViewModel> PendingState(AdminDashboardViewModel obj, string email);
        Task<AdminDashboardViewModel> ProviderDashboard(string email);
        Task TransferCaseToAdmin(int request_id, string reason, string email);
    }
}