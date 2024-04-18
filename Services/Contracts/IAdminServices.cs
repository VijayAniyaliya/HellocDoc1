using Data.Entity;
using HellocDoc1.Services.Models;
using Services.Models;

namespace Services.Contracts
{
    public interface IAdminServices
    {
		Task<AdminDashboardViewModel> NewState(AdminDashboardViewModel obj);

        Task<AdminDashboardViewModel> AdminDashboard();
		Task<AdminDashboardViewModel> PendingState(AdminDashboardViewModel obj);
		Task<AdminDashboardViewModel> ActiveState(AdminDashboardViewModel obj);
		Task<AdminDashboardViewModel> ConcludeState(AdminDashboardViewModel obj);
		Task<AdminDashboardViewModel> ToCloseState(AdminDashboardViewModel obj);
		Task<AdminDashboardViewModel> UnpaidState(AdminDashboardViewModel obj);
        Task<ViewCaseViewModel>  ViewCase(int request_id);
        Task<ViewNotesViewModel> ViewNotes(int request_id);
        Task AddNotes(ViewNotesViewModel model, int request_id, string email);
        Task<CancelCaseViewModel> CancelDetails(int request_id);
        Task CancelCase(int request_id, int caseId, string cancelNote);
        Task<BlockCaseViewModel> BlockDetails(int request_id);
        Task BlockCase(int request_id, string reason);
        Task<AssignCaseViewModel> AssignDetails(int request_id);
        Task<List<PhysicianSelectlViewModel>> FilterData(int regionid);
        Task AssignCase(int request_id, int physicianid, string description);
        Task<ViewUploadsViewModel> ViewUploads(int request_id);
		Task UploadDocuments(ViewUploadsViewModel model, int request_id);
		Task Delete(int DocumentId);
		Task DeleteAll(List<int> DocumentId);
		Task SendMail(List<int> DocumentId);
		Task<LoginResponseViewModel> AdminLogin(AdminLoginViewModel model);
		Task<SendOrdersViewModel> SendOders(int request_id);
		Task<SendOrdersViewModel> FilterDataByProfession(int ProfessionId);
		Task<SendOrdersViewModel> FilterDataByBusiness(int BusinessId);
        Task SendOrderDetails(SendOrdersViewModel model, int request_id);
		Task<TransferCaseViewModel> TransferDetails(int request_id);
        Task TransferCase(int request_id, int physicianid, string description);
        Task<ClearCaseViewModel> ClearDetails(int request_id);
        Task ClearCase(int request_id);
		Task<SendAgreementViewModel> SendAgreementDetails(int request_id);
		Task SendAgreement(string request_id);
		Task<CloseCaseViewModel> CloseCase(int request_id);
        Task SaveCloseCase(CloseCaseViewModel model, int request_id);
        Task CloseCaseRequest(int request_id);
		Task<EncounterFormViewModel> EncounterForm(int request_id);
        Task SubmitEncounterForm(EncounterFormViewModel model, int request_id, string email);
		Task<AdminProfileViewModel> ProfileData(string email);
        Task ResetPassword(string email, string password);
        Task UpdateAdminstrator(ProfileData model, string email);
        Task UpdateBillInfo(BillingData model, string email);
		Task SendLink(SendLinkViewModel model, string email);
        Task SubmitRequest(CreateRequestViewModel model, string role);
        Task<ProviderViewModel> PhysicianData(int region, int requestedPage);
		Task SendMessage(int PhysicianId, string message);
		Task StopNotification(int PhysicianId);
		Task<byte[]> DownloadExcle(AdminDashboardViewModel model);
		Task<ProviderViewModel> provider();
		Task<PhysicianAccountViewModel> EditPhysician(int PhysicianId);
        Task ResetAccountPass(int PhysicianId, string password);
        Task UpdatePhysicianInfo(UpdatePhycisianInfo model);
        Task ModifyBillInfo(ModifyBillingData model);
        Task ModifyProfileInfo(ModifyProfileData model);
        Task<AccessViewModel> AccessData(int requestedPage);
        CreateAccessViewModel CreateAccess(int role_id);
		Task<CreateAccessViewModel> FilterByAccountType(int accounttype, int role_id);
        Task CreateRole(CreateAccessViewModel model, string Email);
		Task<CreatePhysicianViewModel> CreatePhysician();
        Task CreatePhysicianAccount(CreatePhysicianViewModel model, List<int> regionselected);
		Task<CreateAdminViewModel> CreateAdmin();
        Task CreateAdminAccount(CreateAdminViewModel model, List<int> regionselected);
        Task ModifyDocInfo(DocumentDataModel model);
        Task DeleteAccount(int PhysicianId);
        Task UpdateUserInfo(AccountData model);
		Task<SchedullingViewModel> Schedulling();
		Task<SchedullingViewModel> SchedullingData(int region, DateTime date);
        Task DeleteRole(int RoleId);
		Task<CreateNewShift> NewShift();
        Task CreateShift(CreateNewShift model, string Email, List<int> repeatdays);
		Task<CreateNewShift> ViewShift(int PhysicianId);
		Task<VendorsDetailsViewModel> VendorsData();
		Task<VendorsDetailsViewModel> VendorMenu(int profession, string searchvendor, int requestedPage);
		Task<AddBusinessViewModel> AddBusiness(int VendorId);
        Task AddNewBusiness(AddBusinessViewModel model, int VendorId);
        Task DeleteBusiness(int VendorId);
		Task<List<PhysicianLocation>> GetPhysicianlocations();
		Task<SchedullingViewModel> MonthSchedullingData(int region, DateTime date);

        Task ReturnShift(int ShiftDetailId, string email);
        Task DeleteShift(int ShiftDetailId, string email);
        Task EditShift(CreateNewShift model, string email);

        Task<SchedullingViewModel> MdOnCall();
        Task<SchedullingViewModel> MdOnCallData(int region);
        Task<RequestedShiftViewModel> RequestedShifts();
        Task<RequestedShiftViewModel> RequestedShiftsData(int region, int requestedPage);
        Task DeleteSelectedShift(List<int> selectedShifts, string email);
        Task ApproveSelectedShift(List<int> selectedShifts, string email);
   
      
        UserAccessViewModel FetchAccess(int selectedValue);
    }
}