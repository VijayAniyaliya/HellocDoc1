using Data.Entity;
using HellocDoc1.Services.Models;
using Services.Models;

namespace Services.Contracts
{
    public interface IAdminServices
    {
        AdminDashboardViewModel NewState(AdminDashboardViewModel obj);

        AdminDashboardViewModel AdminDashboard();
        AdminDashboardViewModel PendingState(AdminDashboardViewModel obj);
        AdminDashboardViewModel ActiveState(AdminDashboardViewModel obj);
        AdminDashboardViewModel ConcludeState(AdminDashboardViewModel obj);
        AdminDashboardViewModel ToCloseState(AdminDashboardViewModel obj);
        AdminDashboardViewModel UnpaidState(AdminDashboardViewModel obj);
        ViewCaseViewModel  ViewCase(int request_id);
        ViewNotesViewModel ViewNotes(int request_id);
        void AddNotes(ViewNotesViewModel model, int request_id);
        CancelCaseViewModel CancelDetails(int request_id);
        Task CancelCase(int request_id, int caseId, string cancelNote);
        BlockCaseViewModel BlockDetails(int request_id);
        Task BlockCase(int request_id, string reason);
        AssignCaseViewModel AssignDetails(int request_id);
        List<PhysicianSelectlViewModel> FilterData(int regionid);
        Task AssignCase(int request_id, int physicianid, string description);
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
        Task TransferCase(int request_id, int physicianid, string description);
        ClearCaseViewModel ClearDetails(int request_id);
        Task ClearCase(ClearCaseViewModel model, int request_id);
        SendAgreementViewModel SendAgreementDetails(int request_id);
        void SendAgreement(string request_id);
        CloseCaseViewModel CloseCase(int request_id);
        Task SaveCloseCase(CloseCaseViewModel model, int request_id);
        Task CloseCaseRequest(int request_id);
        EncounterFormViewModel EncounterForm(int request_id);
        Task SubmitEncounterForm(EncounterFormViewModel model, int request_id);
        AdminProfileViewModel ProfileData(string email);
        Task ResetPassword(string email, string password);
        Task UpdateAdminstrator(ProfileData model, string email);
        Task UpdateBillInfo(BillingData model, string email);
        void SendLink(SendLinkViewModel model);
        Task SubmitRequest(CreateRequestViewModel model);
        ProviderViewModel PhysicianData(int region);
        void SendMessage(int PhysicianId, string message);
        void StopNotification(int PhysicianId);
        byte[] DownloadExcle(AdminDashboardViewModel model);
        ProviderViewModel provider();
        PhysicianAccountViewModel EditPhysician(int PhysicianId);
        Task ResetAccountPass(int PhysicianId, string password);
        Task UpdatePhysicianInfo(UpdatePhycisianInfo model);
        Task ModifyBillInfo(ModifyBillingData model);
        Task ModifyProfileInfo(ModifyProfileData model);
        AccessViewModel Access();
        CreateAccessViewModel CreateAccess();
        CreateAccessViewModel FilterByAccountType(int accounttype);
        Task CreateRole(CreateAccessViewModel model, string Email);
        CreatePhysicianViewModel CreatePhysician();
        Task CreatePhysicianAccount(CreatePhysicianViewModel model, List<int> regionselected);
        CreateAdminViewModel CreateAdmin();
        Task CreateAdminAccount(CreateAdminViewModel model, List<int> regionselected);
        Task ModifyDocInfo(DocumentDataModel model);
        Task DeleteAccount(int PhysicianId);
        Task UpdateUserInfo(AccountData model);
        SchedullingViewModel Schedulling();
        SchedullingViewModel SchedullingData(int region);
        Task DeleteRole(int RoleId);
        CreateNewShift NewShift();
        Task CreateShift(CreateNewShift model, string Email, List<int> repeatdays);
        CreateNewShift ViewShift(int PhysicianId);
    }
}