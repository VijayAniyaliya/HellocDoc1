using Microsoft.AspNetCore.Mvc;
using Services.Models;

namespace Services.Contracts
{
    public interface IProviderServices
    {
        Task AcceptCase(int request_id);
        Task<AdminDashboardViewModel> ActiveState(AdminDashboardViewModel obj, string email);
        Task AddNotes(ViewNotesViewModel model, int request_id, string email);
        Task<ConcludeCareViewModel> ConcludeCare(int request_id);
        Task ConcludeCase(ConcludeCareViewModel model, string email);
        Task<AdminDashboardViewModel> ConcludeState(AdminDashboardViewModel obj, string email);
        Task Consult(int request_id);
        Task<CreateNewShift> CreateMyShift(string email);
        Task<IActionResult> DownloadEncounter(int request_id);
        Task<PhysicianAccountViewModel> EditPhysician(string email);
        Task finalize(int request_id);
        Task HouseCall(int request_id);
        Task Housecalling(int request_id);
        Task<SchedullingViewModel> MonthWiseMySchedule(DateTime date, string email);
        Task<AdminDashboardViewModel> NewState(AdminDashboardViewModel obj, string email);
        Task<AdminDashboardViewModel> PendingState(AdminDashboardViewModel obj, string email);
        Task<AdminDashboardViewModel> ProviderDashboard(string email);
        Task RequestToAdmin(int PhysicianId, string message);
        Task TransferCaseToAdmin(int request_id, string reason, string email);
        Task UploadDocuments(ConcludeCareViewModel model, int request_id);
    }
}