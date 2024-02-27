using Data.Entity;
using Services.Models;

namespace Services.Contracts
{
    public interface IAdminServices
    {
        AdminDashboardViewModel NewState();

        AdminDashboardViewModel AdminDashboard();
        List<RequestClient> PendingState();
        List<RequestClient> ActiveState();
        List<RequestClient> ConcludeState();
        List<RequestClient> ToCloseState();
        List<RequestClient> UnpaidState();
        ViewCaseViewModel  ViewCase(int request_id);
    }
}