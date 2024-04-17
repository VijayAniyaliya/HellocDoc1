using Common.Helpers;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Implementation;
using Services.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace HellocDoc1.Controllers
{
    [Route("[controller]/[action]")]
    [CustomAuthorize("Physician")]
    public class ProviderController : Controller
    {
        private readonly IProviderServices _providerServices;
        private readonly IAdminServices _adminServices;
        public ProviderController(IProviderServices providerServices, IAdminServices adminServices)
        {
            _providerServices = providerServices;
            _adminServices = adminServices;
        }

        public async Task<IActionResult> ProviderDashboard()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var data = await _providerServices.ProviderDashboard(email!);
            return View(data);
        }

        public async Task<IActionResult> NewState(AdminDashboardViewModel obj)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var data = await _providerServices.NewState(obj, email!);
            return PartialView("_NewState", data);
        }

        public async Task<IActionResult> PendingState(AdminDashboardViewModel obj)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var data = await _providerServices.PendingState(obj, email!);
            return PartialView("_PendingState", data);
        }
        public async Task<IActionResult> ActiveState(AdminDashboardViewModel obj)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var data = await _providerServices.ActiveState(obj, email!);
            return PartialView("_ActiveState", data);
        }
        public async Task<IActionResult> ConcludeState(AdminDashboardViewModel obj)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var data = await _providerServices.ConcludeState(obj, email!);
            return PartialView("_ConcludeState", data);
        }

        public async Task<IActionResult> AcceptCase(int request_id)
        {
            await _providerServices.AcceptCase(request_id);
            return NoContent();
        }

        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");
            return RedirectToAction("AdminLogin", "Admin");
        }

        public async Task<IActionResult> ViewCase(int request_id)
        {
            ViewCaseViewModel data = await _adminServices.ViewCase(request_id);
            return View(data);
        }

        public async Task<IActionResult> ViewNotes(int request_id)
        {
            ViewNotesViewModel data = await _adminServices.ViewNotes(request_id);
            return View(data);
        }

        public async Task<IActionResult> AddNotes(ViewNotesViewModel model, int request_id)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            await _providerServices.AddNotes(model, request_id, email);
            return RedirectToAction("ViewNotes", new { request_id = request_id });
        }

        public async Task<IActionResult> ViewUploads(int request_id)
        {
            var model = await _adminServices.ViewUploads(request_id);
            return View(model);
        }

        public async Task<IActionResult> Delete(int DocumentId, int RequestId)
        {
            await _adminServices.Delete(DocumentId);
            return RedirectToAction("ViewUploads", new { request_id = RequestId });
        }
        public async Task<IActionResult> DeleteAll([FromBody] List<int> DocumentId)
        {
            await _adminServices.DeleteAll(DocumentId);
            return RedirectToAction("ProviderDashboard");
        }

        public async Task<IActionResult> SendMail(List<int> DocumentId)
        {
            await _adminServices.SendMail(DocumentId);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> UploadDocuments(ViewUploadsViewModel model, int request_id)
        {
            await _adminServices.UploadDocuments(model, request_id);
            return RedirectToAction("ViewUploads", new { request_id = request_id });
        }

        public async Task<IActionResult> SendAgreementDetails(int request_id)
        {
            var data = await _adminServices.SendAgreementDetails(request_id);
            return PartialView("_SendAgreement", data);
        }

        public async Task<IActionResult> SendAgreement(int request_id)
        {
            string RequestId = HashingServices.Encrypt(request_id.ToString());
            await _adminServices.SendAgreement(RequestId);
            return NoContent();
        }

        public async Task<IActionResult> TransferCaseDetails(int request_id)
        {
            ClearCaseViewModel data = await _adminServices.ClearDetails(request_id);
            return PartialView(data);
        }

        public async Task<IActionResult> TransferCaseToAdmin(int request_id, string reason)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            await _providerServices.TransferCaseToAdmin(request_id, reason, email!);
            return RedirectToAction("PrviderDashboard");
        }

        public async Task<IActionResult> SendOrders(int request_id)
        {
            var data = await _adminServices.SendOders(request_id);
            return View(data);
        }

        public async Task<SendOrdersViewModel> FilterDataByProfession(int ProfessionId)
        {
            SendOrdersViewModel data = await _adminServices.FilterDataByProfession(ProfessionId);
            return data;
        }

        public async Task<SendOrdersViewModel> FilterDataByBusiness(int BusinessId)
        {
            SendOrdersViewModel data = await _adminServices.FilterDataByBusiness(BusinessId);
            return data;
        }

        [HttpPost]
        public async Task<IActionResult> SendOrderDetails(SendOrdersViewModel model, int request_id)
        {
            await _adminServices.SendOrderDetails(model, request_id);
            TempData["Success"] = "Order Sended Succefully";
            return RedirectToAction("ProviderDashboard");
        }

        [HttpPost]
        public IActionResult HouseCallDetails(int request_id)
        {
            HouseCallViewModel model = new HouseCallViewModel()
            {
                RequestId = request_id,
            };
            return PartialView("_HouseCall", model);
        }

        [HttpPost]
        public IActionResult DownloadEncounter(int request_id)
        {
            HouseCallViewModel model = new HouseCallViewModel()
            {
                RequestId = request_id,
            };
            return PartialView("_DownloadEncounter", model);
        }

        public async Task<IActionResult> Consult(int request_id)
        {
            await _providerServices.Consult(request_id);
            return NoContent();
        }

        public async Task<IActionResult> HouseCall(int request_id)
        {
            await _providerServices.HouseCall(request_id);
            return NoContent();
        }

        public async Task<IActionResult> Housecalling(int request_id)
        {
            await _providerServices.Housecalling(request_id);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Encounter(int request_id)
        {
            var data = await _adminServices.EncounterForm(request_id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitEncounterForm(EncounterFormViewModel model, int request_id)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            await _adminServices.SubmitEncounterForm(model, request_id, email);
            TempData["Success"] = "Encounter form succefully submitted";
            return RedirectToAction("ProviderDashboard");
        }

        [HttpPost]
        public async Task<IActionResult> finalize(int request_id)
        {
            await _providerServices.finalize(request_id);
            TempData["Success"] = "Encounter form succefully finalized";
            return RedirectToAction("ProviderDashboard");
        }

        public async Task<IActionResult> ConcludeCare(int request_id)
        {
            var data = await _providerServices.ConcludeCare(request_id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> UploadEncounter(ConcludeCareViewModel model, int request_id)
        {
            await _providerServices.UploadDocuments(model, request_id); 
            return RedirectToAction("ConcludeCare", new { request_id = request_id });
        }

        public async Task<IActionResult> ConcludeCase(ConcludeCareViewModel model)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            await _providerServices.ConcludeCase(model, email);
            TempData["Success"] = "Case concluded Successfully";
            return RedirectToAction("ProviderDashboard");
        }

        public IActionResult MySchedulle()
        {
            return View();
        }

        public async Task<IActionResult> MonthWiseMySchedule(DateTime date)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var data = await _providerServices.MonthWiseMySchedule(date, email);
            return PartialView("_MonthWiseMySchedulle", data);
        }

        public async Task<IActionResult> CreateMyShiftView()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var data = await _providerServices.CreateMyShift(email);
            return PartialView("_CreateMyShift", data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateShift(CreateNewShift model, List<int> repeatdays)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            await _adminServices.CreateShift(model, email, repeatdays);
            TempData["Success"] = "Shift Created Successfully";
            return RedirectToAction("MySchedulle");
        }

        public async Task<IActionResult> MyProfile()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var data = await _providerServices.EditPhysician(email);
            return View(data);
        }

        public async Task<IActionResult> ResetAccountPass(int PhysicianId, string password)
        {
            await _adminServices.ResetAccountPass(PhysicianId, password);
            return NoContent();
        }

        public IActionResult RequestToAdminDetails(int PhysicianId)
        {
            TransferCaseViewModel model = new TransferCaseViewModel()
            {
                PhysicianId = PhysicianId,
            };
            return PartialView("_RequestToAdmin", model); ;
        }

        public async Task<IActionResult> RequestToAdmin(int PhysicianId, string message)
         {
            await _providerServices.RequestToAdmin(PhysicianId, message);
            return NoContent();
        }

        public IActionResult SendMailDetails()
        {
            return PartialView("_SendLinkByProvider");
        }

        public async Task SendLink(SendLinkViewModel model)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            await _adminServices.SendLink(model, email);
        }

        public IActionResult CreateRequestByProvider()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRequest(CreateRequestViewModel model)
        {
            var roles = User.FindAll(ClaimTypes.Role).Select(c => c.Value).ToList();
            var role = roles.FirstOrDefault();
            await _adminServices.SubmitRequest(model, role);
            TempData["success"] = "Request Submitted Successfully";
            return RedirectToAction("ProviderDashboard");
        }
    }
}
