using HellocDoc1.DataModels;

namespace HellocDoc1.Services
{
    public interface IPatientServices
    {
        List<Request> DashboardService(string Email);
    }
}