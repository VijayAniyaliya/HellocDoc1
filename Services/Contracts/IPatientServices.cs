using Data.Entity;
using HellocDoc1.Services.Models;

namespace Services.Contracts
{
    public interface IPatientServices
    {
        List<Request> DashboardService(string Email);

        PatientServiceModel DocumentService(int Requestid);
        void Editing(string Email, User model);
        User ProfileService(string Email);
    }
}