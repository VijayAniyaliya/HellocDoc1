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
        ViewNotesViewModel ViewNotes(int request_id);
        void AddNotes(ViewNotesViewModel model, int request_id);
        CancelCaseViewModel CancelDetails(int request_id);
        Task CancelCase(CancelCaseViewModel model, int request_id);
        BlockCaseViewModel BlockDetails(int request_id);
        Task BlockCase(BlockCaseViewModel model, int request_id);
        AssignCaseViewModel AssignDetails(int request_id);
        List<PhysicianSelectlViewModel> FilterData(int regionid);
        Task AssignCase(AssignCaseViewModel model, int request_id);
    }
}