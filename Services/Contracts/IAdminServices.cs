using Data.Entity;
using Services.Models;

namespace Services.Contracts
{
    public interface IAdminServices
    {
        AdminDashboardViewModel NewState();

        AdminDashboardViewModel AdminDashboard();
    }
}