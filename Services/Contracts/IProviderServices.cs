using Services.Models;

namespace Services.Contracts
{
    public interface IProviderServices
    {
        Task<AdminDashboardViewModel> ActiveState(AdminDashboardViewModel obj);
        Task<AdminDashboardViewModel> ConcludeState(AdminDashboardViewModel obj);
        Task<AdminDashboardViewModel> NewState(AdminDashboardViewModel obj);
        Task<AdminDashboardViewModel> PendingState(AdminDashboardViewModel obj);
        Task<AdminDashboardViewModel> ProviderDashboard();
    }
}