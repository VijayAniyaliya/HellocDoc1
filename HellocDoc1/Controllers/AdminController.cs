using Common.Enum;
using Common.Helpers;
using Data.Entity;
using HellocDoc1.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Implementation;
using Services.Models;
using System.Drawing.Drawing2D;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace HellocDoc1.Controllers
{
    [Route("[controller]/[action]")]

    public class AdminController : Controller
    {
        private readonly IAdminServices _adminServices;
        private readonly IPatientServices _patientServices;
        private readonly IRecordsServices _recordsServices;

        public AdminController(IAdminServices adminServices, IRecordsServices recordsServices, IPatientServices patientServices)
        {
            _adminServices = adminServices;
            _recordsServices = recordsServices;
            _patientServices = patientServices;
        }

        //[CustomAuthorize("Admin", "AdminDashboard")]
        public async Task<IActionResult> AdminDashboard()
        {
            AdminDashboardViewModel model = new AdminDashboardViewModel();
            model = await _adminServices.AdminDashboard();
            return View(model);
        }

        //[CustomAuthorize("Admin", "AdminDashboard")]

        public async Task<IActionResult> NewState(AdminDashboardViewModel obj)
        {
            AdminDashboardViewModel model = await _adminServices.NewState(obj);
            return View(model);
        }

        [CustomAuthorize("Admin", "AdminDashboard")]

        public async Task<IActionResult> PendingState(AdminDashboardViewModel obj)
        {
            AdminDashboardViewModel model = await _adminServices.PendingState(obj);
            return View(model);
        }

        [CustomAuthorize("Admin", "AdminDashboard")]

        public async Task<IActionResult> ActiveState(AdminDashboardViewModel obj)
        {
            AdminDashboardViewModel model = await _adminServices.ActiveState(obj);
            return View(model);
        }

        [CustomAuthorize("Admin", "AdminDashboard")]

        public async Task<IActionResult> ConcludeState(AdminDashboardViewModel obj)
        {
            AdminDashboardViewModel model = await _adminServices.ConcludeState(obj);
            return View(model);
        }


        [CustomAuthorize("Admin", "AdminDashboard")]

        public async Task<IActionResult> ToCloseState(AdminDashboardViewModel obj)
        {
            AdminDashboardViewModel model = await _adminServices.ToCloseState(obj);
            return View(model);
        }


        [CustomAuthorize("Admin", "AdminDashboard")]

        public async Task<IActionResult> UnpaidState(AdminDashboardViewModel obj)
        {
            AdminDashboardViewModel model = await _adminServices.UnpaidState(obj);
            return View(model);
        }


        [CustomAuthorize("Admin", "ViewCase")]

        public async Task<IActionResult> ViewCase(int request_id)
        {
            ViewCaseViewModel data = await _adminServices.ViewCase(request_id);
            return View(data);
        }


        [CustomAuthorize("Admin", "ViewCase")]

        public async Task<IActionResult> UpdateRequest(ViewCaseViewModel model)
        {
            await _adminServices.UpdateRequest(model);
            return NoContent();
        }


        [CustomAuthorize("Admin", "ViewNotes")]

        public async Task<IActionResult> ViewNotes(int request_id)
        {
            ViewNotesViewModel data = await _adminServices.ViewNotes(request_id);
            return View(data);
        }

        [CustomAuthorize("Admin", "ViewNotes")]
        public async Task<IActionResult> AddNotes(AddNotesViewModel model)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            await _adminServices.AddNotes(model, email);
            return NoContent();
        }

        [CustomAuthorize("Admin", "AdminDashboard")]

        [HttpPost("{request_id}")]
        public async Task<IActionResult> CancelDetails(int request_id)
        {
            CancelCaseViewModel data = await _adminServices.CancelDetails(request_id);
            return PartialView("_CancelCase", data);
        }

        [CustomAuthorize("Admin", "AdminDashboard")]


        public async Task<IActionResult> CancelCase(int request_id, int caseId, string cancelNote)
        {
            await _adminServices.CancelCase(request_id, caseId, cancelNote);
            return RedirectToAction("AdminDashboard");
        }

        [CustomAuthorize("Admin", "AdminDashboard")]


        [HttpPost("{request_id}")]
        public async Task<IActionResult> AssignDetails(int request_id)
        {
            AssignCaseViewModel data = await _adminServices.AssignDetails(request_id);
            return PartialView("_AssignCase", data);
        }

        [CustomAuthorize("Admin", "AdminDashboard")]

        public async Task<List<PhysicianSelectlViewModel>> FilterData(int regionid)
        {
            List<PhysicianSelectlViewModel> data = await _adminServices.FilterData(regionid);
            return data;
        }

        [CustomAuthorize("Admin", "AdminDashboard")]

        public async Task<IActionResult> AssignCase(int request_id, int physicianid, string description)
        {
            await _adminServices.AssignCase(request_id, physicianid, description);
            return NoContent();
        }

        [CustomAuthorize("Admin", "AdminDashboard")]

        [HttpPost("{request_id}")]
        public async Task<IActionResult> BlockDetails(int request_id)
        {
            BlockCaseViewModel data = await _adminServices.BlockDetails(request_id);
            return PartialView("_BlockCase", data);
        }

        [CustomAuthorize("Admin", "AdminDashboard")]

        public async Task<IActionResult> BlockCase(int request_id, string reason)
        {
            await _adminServices.BlockCase(request_id, reason);
            return RedirectToAction("AdminDashboard");
        }

        [CustomAuthorize("Admin", "ViewUploads")]

        public async Task<IActionResult> ViewUploads(int request_id)
        {
            var model = await _adminServices.ViewUploads(request_id);
            return View(model);
        }

        [CustomAuthorize("Admin", "ViewUploads")]

        [HttpPost]
        public async Task<IActionResult> UploadDocuments(ViewUploadsViewModel model, int request_id)
        {
            await _adminServices.UploadDocuments(model, request_id);
            return RedirectToAction("ViewUploads", new { request_id = request_id });
        }

        [CustomAuthorize("Admin", "ViewUploads")]

        public async Task<IActionResult> Delete(int DocumentId, int RequestId)
        {
            await _adminServices.Delete(DocumentId);
            return RedirectToAction("ViewUploads", new { request_id = RequestId });
        }

        [CustomAuthorize("Admin", "ViewUploads")]

        public async Task<IActionResult> DeleteAll(int[] DocumentId)
        {
            await _adminServices.DeleteAll(DocumentId);
            return RedirectToAction("AdminDashboard");
        }


        [CustomAuthorize("Admin", "ViewUploads")]

        public async Task<IActionResult> DownloadAll(int request_id)
        {
            var download = await _recordsServices.DownloadFilesForRequest(request_id);
            return File(download, "application/zip", "RequestFiles.zip");
        }


        [CustomAuthorize("Admin", "ViewUploads")]

        public async Task<IActionResult> SendMail(List<int> DocumentId)
        {
            await _adminServices.SendMail(DocumentId);
            return RedirectToAction("AdminDashboard");
        }


        [CustomAuthorize("Admin", "SendOrders")]

        public async Task<IActionResult> SendOrders(int request_id)
        {
            var data = await _adminServices.SendOders(request_id);
            return View(data);
        }


        [CustomAuthorize("Admin", "SendOrders")]

        public async Task<SendOrdersViewModel> FilterDataByProfession(int ProfessionId)
        {
            SendOrdersViewModel data = await _adminServices.FilterDataByProfession(ProfessionId);
            return data;
        }


        [CustomAuthorize("Admin", "SendOrders")]

        public async Task<SendOrdersViewModel> FilterDataByBusiness(int BusinessId)
        {
            SendOrdersViewModel data = await _adminServices.FilterDataByBusiness(BusinessId);
            return data;
        }


        [CustomAuthorize("Admin", "SendOrders")]

        [HttpPost]
        public async Task<IActionResult> SendOrderDetails(SendOrdersViewModel model, int request_id)
        {
            await _adminServices.SendOrderDetails(model, request_id);
            return RedirectToAction("AdminDashboard");
        }


        [CustomAuthorize("Admin", "AdminDashboard")]

        public async Task<IActionResult> TransferDetails(int request_id)
        {
            var data = await _adminServices.TransferDetails(request_id);
            return PartialView("_TransferCase", data);
        }


        [CustomAuthorize("Admin", "AdminDashboard")]

        public async Task<IActionResult> TransferCase(int request_id, int physicianid, string description)
        {
            await _adminServices.TransferCase(request_id, physicianid, description);
            return RedirectToAction("AdminDashboard");
        }

        [CustomAuthorize("Admin", "AdminDashboard")]

        public async Task<IActionResult> ClearDetails(int request_id)
        {
            var data = await _adminServices.ClearDetails(request_id);
            return PartialView("_ClearCase", data);
        }

        [CustomAuthorize("Admin", "AdminDashboard")]

        public async Task<IActionResult> ClearCase(int request_id)
        {
            await _adminServices.ClearCase(request_id);
            return RedirectToAction("AdminDashboard");
        }

        [CustomAuthorize("Admin", "AdminDashboard")]

        public async Task<IActionResult> SendAgreementDetails(int request_id)
        {
            var data = await _adminServices.SendAgreementDetails(request_id);
            return PartialView("_SendAgreement", data);
        }

        [CustomAuthorize("Admin", "AdminDashboard")]

        public async Task<IActionResult> SendAgreement(int request_id)
        {
            string RequestId = HashingServices.Encrypt(request_id.ToString());
            await _adminServices.SendAgreement(RequestId);
            return NoContent();
        }


        [CustomAuthorize("Admin", "CloseCase")]

        public async Task<IActionResult> CloseCase(int request_id)
        {
            var data = await _adminServices.CloseCase(request_id);
            return View(data);
        }

        [CustomAuthorize("Admin", "CloseCase")]

        [HttpPost]
        public async Task<IActionResult> SaveCloseCase(CloseCaseViewModel model, int request_id)
        {
            await _adminServices.SaveCloseCase(model, request_id);
            return RedirectToAction("CloseCase", new { request_id });
        }

        [CustomAuthorize("Admin", "CloseCase")]

        public async Task CloseCaseRequest(int request_id)
        {
            await _adminServices.CloseCaseRequest(request_id);
            TempData["Success"] = "Case Successfully Closed";
        }

        [CustomAuthorize("Admin", "Encounter")]

        [HttpGet]
        public async Task<IActionResult> EncounterForm(int request_id)
        {
            var data = await _adminServices.EncounterForm(request_id);
            return View(data);
        }

        [CustomAuthorize("Admin", "Encounter")]

        [HttpPost]
        public async Task<IActionResult> SubmitEncounterForm(EncounterFormViewModel model, int request_id)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            await _adminServices.SubmitEncounterForm(model, request_id, email);
            TempData["Success"] = "Encounter form succefully submitted";
            return RedirectToAction("AdminDashboard");
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> AdminLogin(AdminLoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                LoginResponseViewModel? result = await _adminServices.AdminLogin(user);
                if (result.Status == ResponseStatus.Success)
                {
                    Response.Cookies.Append("jwt", result.Token);
                    HttpContext.Session.SetString("Email", user.Email);
                    string token = result.Token;
                    if (JwtService.ValidateToken(token, out JwtSecurityToken jwtSecurityToken))
                    {
                        IEnumerable<Claim> rolesClaims = jwtSecurityToken.Claims.Where(c => c.Type == ClaimTypes.Role);
                        var roles = rolesClaims.Select(c => c.Value);
                        if (roles.FirstOrDefault() == "Admin")
                        {
                            TempData["Success"] = "Login Successfully";
                            return RedirectToAction("AdminDashboard", "Admin");
                        }
                        else if (roles.FirstOrDefault() == "Physician")
                        {
                            TempData["Success"] = "Login Successfully";
                            return RedirectToAction("ProviderDashboard", "Provider");
                        }
                        else
                        {
                            return RedirectToAction("AccessdDenied", "Auth");
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                    TempData["Error"] = result.Message;
                    return View();
                }
            }
            return View();
        }

        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");
            return RedirectToAction("AdminLogin");
        }

        [AllowAnonymous]
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> AdminForget(AdminLoginViewModel model)
        {
            LoginResponseViewModel? result = await _adminServices.ForgetPassword(model);
            if (result.Status == ResponseStatus.Success)
            {
                TempData["Success"] = "Reset Password link sent to your email";
                return RedirectToAction("AdminLogin", "Admin");
            }
            else
            {
                ModelState.AddModelError("", result.Message);
                TempData["Error"] = result.Message;
                return View("ForgetPassword");

            }
        }

        [AllowAnonymous]
        [HttpGet("{email}")]
        public IActionResult ResetYourPassword(string email)
        {
            string Email = HashingServices.Decrypt(email);
            ViewBag.Email = Email;
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ResetPasswords(ChangePassViewModel model)
        {
            await _adminServices.ResetPassword(model);
            return RedirectToAction("AdminLogin", "Admin");
        }

        [CustomAuthorize("Admin", "MyProfile")]

        public async Task<IActionResult> AdminProfile()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var data = await _adminServices.ProfileData(email);
            return View(data);
        }


        [CustomAuthorize("Admin", "MyProfile")]

        public async Task<IActionResult> ResetAdminPassword(string password)
        {
            var email = HttpContext.Session.GetString("Email");
            await _adminServices.ResetAdminPassword(email, password);
            return NoContent();
        }


        [CustomAuthorize("Admin", "MyProfile")]

        [HttpPost]
        public async Task<IActionResult> UpdateAdminstrator(ProfileData model)
        {
            var email = HttpContext.Session.GetString("Email");
            await _adminServices.UpdateAdminstrator(model, email);
            return NoContent();
        }


        [CustomAuthorize("Admin", "MyProfile")]

        [HttpPost]
        public async Task<IActionResult> UpdateBillInfo(BillingData model)
        {
            var email = HttpContext.Session.GetString("Email");
            await _adminServices.UpdateBillInfo(model, email);
            return NoContent();
        }


        [CustomAuthorize("Admin", "Providers")]

        public async Task<IActionResult> Provider()
        {
            var data = await _adminServices.provider();
            return View(data);
        }

        [CustomAuthorize("Admin", "Providers")]

        public async Task<IActionResult> ProviderMenu(int region, int requestedPage)
        {
            var data = await _adminServices.PhysicianData(region, requestedPage);
            return PartialView("_ProviderMenu", data);
        }


        [CustomAuthorize("Admin", "Providers")]

        public async Task<IActionResult> StopNotification(int PhysicianId)
        {
            await _adminServices.StopNotification(PhysicianId);
            return NoContent();
        }


        [CustomAuthorize("Admin", "Providers")]

        public IActionResult ContactProvider(int PhysicianId)
        {
            PhysicianData physicianData = new PhysicianData();
            physicianData.physicianId = PhysicianId;
            return PartialView("_ContactProvider", physicianData);
        }


        [CustomAuthorize("Admin", "Providers")]

        public async Task<IActionResult> SendMessage(int PhysicianId, string message, int type)
        {
            await _adminServices.SendMessage(PhysicianId, message, type);
            return Json("");
        }


        [CustomAuthorize("Admin", "AdminDashboard")]

        public IActionResult SendMailDetails()
        {
            return PartialView("_SendMail");
        }


        [CustomAuthorize("Admin", "AdminDashboard")]

        public async Task SendLink(SendLinkViewModel model)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            await _adminServices.SendLink(model, email);
        }

        [CustomAuthorize("Admin", "AdminDashboard")]

        public IActionResult CreateRequest()
        {
            return View();
        }


        [CustomAuthorize("Admin", "AdminDashboard")]

        public async Task<IActionResult> ExportData(AdminDashboardViewModel obj)
        {
            int CurrentPage = 0;
            int PageSize = 10;
            AdminDashboardViewModel model = new AdminDashboardViewModel();
            switch (obj.status)
            {
                case 1:
                    model = await _adminServices.NewState(obj);
                    break;
                case 2:
                    model = await _adminServices.PendingState(obj);
                    break;
                case 3:
                    model = await _adminServices.ActiveState(obj);
                    break;
                case 4:
                    model = await _adminServices.ConcludeState(obj);
                    break;
                case 5:
                    model = await _adminServices.ToCloseState(obj);
                    break;
                case 6:
                    model = await _adminServices.UnpaidState(obj);
                    break;
            }
            var record = await _adminServices.DownloadExcle(model);
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            var strDate = DateTime.Now.ToString("yyyyMMdd");
            string filename = $"{obj.status}_{strDate}.xlsx";
            return File(record, contentType, filename);
        }

        [CustomAuthorize("Admin", "AdminDashboard")]

        public async Task<IActionResult> ExportDataAll()
        {
            var data = await _adminServices.ExportAll();
            var record = await _adminServices.DownloadExcle(data);
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            var strDate = DateTime.Now.ToString("yyyyMMdd");
            string filename = $"Patient_Data.xlsx";
            return File(record, contentType, filename);
        }

        [CustomAuthorize("Admin", "AdminDashboard")]

        public IActionResult RequestSupportDetails()
        {
            return PartialView("_RequestSupport");
        }

        [CustomAuthorize("Admin", "AdminDashboard")]

        public async Task<IActionResult> RequestSupport(string message)
        {
            await _adminServices.RequestSupport(message);
            return NoContent();
        }

        [CustomAuthorize("Admin", "AdminDashboard")]

        [HttpPost]
        public async Task<IActionResult> CreateRequest(CreateRequestViewModel model)
        {
            var roles = User.FindAll(ClaimTypes.Role).Select(c => c.Value).ToList();
            var role = roles.FirstOrDefault();
            var Email = User.FindFirstValue(ClaimTypes.Email);
            await _adminServices.SubmitRequest(model, role, Email);
            TempData["success"] = "Request Submitted Successfully";
            return RedirectToAction("AdminDashboard");
        }

        [CustomAuthorize("Admin", "EditPhysician")]

        public async Task<IActionResult> EditPhysician(int PhysicianId)
        {
            var data = await _adminServices.EditPhysician(PhysicianId);
            return View(data);
        }

        [CustomAuthorize("Admin", "EditPhysician")]

        public async Task<IActionResult> ResetAccountPass(int PhysicianId, string password)
        {
            await _adminServices.ResetAccountPass(PhysicianId, password);
            return NoContent();
        }

        [CustomAuthorize("Admin", "EditPhysician")]

        public async Task<IActionResult> UpdateUserInfo(AccountData model)
        {
            await _adminServices.UpdateUserInfo(model);
            return NoContent();
        }

        [CustomAuthorize("Admin", "EditPhysician")]

        [HttpPost]
        public async Task<IActionResult> UpdatePhysicianInfo(UpdatePhycisianInfo model)
        {
            await _adminServices.UpdatePhysicianInfo(model);
            return NoContent();
        }

        [CustomAuthorize("Admin", "EditPhysician")]

        [HttpPost]
        public async Task<IActionResult> ModifyBillInfo(ModifyBillingData model)
        {
            await _adminServices.ModifyBillInfo(model);
            return NoContent();
        }

        [CustomAuthorize("Admin", "EditPhysician")]

        [HttpPost]
        public async Task<IActionResult> ModifyProfileInfo(ModifyProfileData model)
        {
            await _adminServices.ModifyProfileInfo(model);
            return NoContent();
        }

        [CustomAuthorize("Admin", "EditPhysician")]

        public async Task<IActionResult> ModifyDocInfo(DocumentDataModel model)
        {
            await _adminServices.ModifyDocInfo(model);
            return Json("");
        }

        [CustomAuthorize("Admin", "EditPhysician")]

        public async Task<IActionResult> DeleteAccount(int PhysicianId)
        {
            await _adminServices.DeleteAccount(PhysicianId);
            return Ok();
        }

        //[CustomAuthorize("Admin", "Access")]

        public IActionResult Access()
        {
            return View();
        }

        //[CustomAuthorize("Admin", "Access")]

        [HttpPost]
        public async Task<IActionResult> AccessData(int requestedPage)
        {
            var data = await _adminServices.AccessData(requestedPage);
            return PartialView("_AccountAccessData", data);
        }

        //[CustomAuthorize("Admin", "CreateAccess")]

        public IActionResult CreateAccess(int role_id)
        {
            var data = _adminServices.CreateAccess(role_id);
            return View(data);
        }


        //[CustomAuthorize("Admin", "CreateAccess")]

        public async Task<IActionResult> DeleteRole(int RoleId)
        {
            await _adminServices.DeleteRole(RoleId);
            return NoContent();
        }


        //[CustomAuthorize("Admin", "CreateAccess")]

        public async Task<IActionResult> FilterByAccountType(int accounttype, int role_id)
        {
            var data = await _adminServices.FilterByAccountType(accounttype, role_id);
            return PartialView("_MenuData", data);
        }


        //[CustomAuthorize("Admin", "CreateAccess")]

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateAccessViewModel model)
        {
            var email = HttpContext.Session.GetString("Email");
            await _adminServices.CreateRole(model, email);
            return Ok();
        }


        [CustomAuthorize("Admin", "CreateProvider")]

        public async Task<IActionResult> CreatePhysician()
        {
            var data = await _adminServices.CreatePhysician();
            return View(data);
        }


        [CustomAuthorize("Admin", "CreateProvider")]

        [HttpPost]
        public async Task<IActionResult> CreatePhysicianAccount(CreatePhysicianViewModel model, List<int> regionselected)
        {
            await _adminServices.CreatePhysicianAccount(model, regionselected);
            return RedirectToAction("Provider");
        }


        //[CustomAuthorize("Admin", "CreateAdmin")]

        public async Task<IActionResult> CreateAdmin()
        {
            var data = await _adminServices.CreateAdmin();
            return View(data);
        }


        //[CustomAuthorize("Admin", "CreateAdmin")]

        [HttpPost]
        public async Task<IActionResult> CreateAdminAccount(CreateAdminViewModel model, List<int> regionselected)
        {
            await _adminServices.CreateAdminAccount(model, regionselected);
            return RedirectToAction("Access");
        }


        //[CustomAuthorize("Admin", "UserAccess")]

        public IActionResult UserAccess()
        {
            return View();
        }


        //[CustomAuthorize("Admin", "UserAccess")]

        [HttpGet]
        public IActionResult ShowUserAccess(int selectedValue)
        {
            var obj = _adminServices.FetchAccess(selectedValue);
            return PartialView("_UserAccessTable", obj);
        }



        [CustomAuthorize("Admin", "Schedulling")]

        public async Task<IActionResult> Schedulling()
        {
            var data = await _adminServices.Schedulling();
            return View(data);
        }


        [CustomAuthorize("Admin", "Schedulling")]

        public async Task<IActionResult> SchedullingData(int region, DateTime date)
        {
            var data = await _adminServices.SchedullingData(region, date);
            return PartialView("_SchedullingData", data);
        }

        [CustomAuthorize("Admin", "Schedulling")]

        public async Task<IActionResult> WeekSchedullingData(int region, DateTime date)
        {
            var data = await _adminServices.SchedullingData(region, date);
            return PartialView("_WeekWiseSchedulling", data);
        }

        [CustomAuthorize("Admin", "Schedulling")]

        public async Task<IActionResult> MonthSchedullingData(int region, DateTime date)
        {
            var data = await _adminServices.MonthSchedullingData(region, date);
            return PartialView("_MonthWiseSchedulling", data);
        }

        [CustomAuthorize("Admin", "Schedulling")]

        public async Task<IActionResult> NewShift()
        {
            var data = await _adminServices.NewShift();
            return PartialView("_CreateNewShift", data);
        }

        [CustomAuthorize("Admin", "Schedulling")]

        public async Task<IActionResult> ViewShift(int ShiftDetailId)
        {
            var data = await _adminServices.ViewShift(ShiftDetailId);
            return PartialView("_ViewShift", data);
        }

        [CustomAuthorize("Admin", "Schedulling")]

        public async Task<IActionResult> ReturnShift(int ShiftDetailId)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            await _adminServices.ReturnShift(ShiftDetailId, email);
            TempData["Success"] = "Shift Return Successfully";
            return RedirectToAction("Schedulling");
        }

        [CustomAuthorize("Admin", "Schedulling")]

        public async Task<IActionResult> DeleteShift(int ShiftDetailId)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            await _adminServices.DeleteShift(ShiftDetailId, email);
            TempData["Success"] = "Shift Deleted Successfully";
            return RedirectToAction("Schedulling");
        }

        [CustomAuthorize("Admin", "Schedulling")]

        public async Task<IActionResult> EditShift(CreateNewShift model)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            await _adminServices.EditShift(model, email);
            TempData["Success"] = "Shift Edited Successfully";
            return NoContent();
        }

        [CustomAuthorize("Admin", "Schedulling")]

        [HttpPost]
        public async Task<IActionResult> CreateShift(CreateNewShift model, List<int> repeatdays)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var iscreated = await _adminServices.CreateShift(model, email, repeatdays);
            if (iscreated)
            {
                TempData["Success"] = "Shift Created Successfully";
            }
            else
            {   
                TempData["Error"] = "Shift is already created in  this time";
            }
            return RedirectToAction("Schedulling");
        }

        [CustomAuthorize("Admin", "MdOnCall")]

        public async Task<IActionResult> MdOnCall()
        {
            var data = await _adminServices.MdOnCall();
            return View(data);
        }

        [CustomAuthorize("Admin", "MdOnCall")]

        public async Task<IActionResult> MdOnCallData(int region)
        {
            var data = await _adminServices.MdOnCallData(region);
            return PartialView("_MdOnCallData", data);
        }

        [CustomAuthorize("Admin", "RequestedShifts")]

        public async Task<IActionResult> RequestedShifts()
        {
            var data = await _adminServices.RequestedShifts();
            return View(data);
        }

        [CustomAuthorize("Admin", "RequestedShifts")]

        public async Task<IActionResult> RequestedShiftData(int region, int requestedPage)
        {
            var data = await _adminServices.RequestedShiftsData(region, requestedPage);
            return PartialView("_RequestedShiftData", data);
        }

        [CustomAuthorize("Admin", "RequestedShifts")]

        public async Task<IActionResult> DeleteSelectedShift(List<int> selectedShifts)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            await _adminServices.DeleteSelectedShift(selectedShifts, email);
            return NoContent();
        }

        [CustomAuthorize("Admin", "RequestedShifts")]

        public async Task<IActionResult> ApproveSelectedShift(List<int> selectedShifts)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            await _adminServices.ApproveSelectedShift(selectedShifts, email);
            return NoContent();
        }


        [CustomAuthorize("Admin", "Partners")]

        public async Task<IActionResult> Vendors()
        {
            var data = await _adminServices.VendorsData();
            return View(data);
        }

        [CustomAuthorize("Admin", "Partners")]

        public async Task<IActionResult> VendorMenu(int profession, string searchvendor, int requestedPage)
        {
            var data = await _adminServices.VendorMenu(profession, searchvendor, requestedPage);
            return PartialView("_VendorsData", data);
        }

        [CustomAuthorize("Admin", "AddBusiness")]

        public async Task<IActionResult> AddBusiness(int VendorId)
        {
            var data = await _adminServices.AddBusiness(VendorId);
            return View(data);
        }

        [CustomAuthorize("Admin", "AddBusiness")]

        public async Task<IActionResult> AddNewBusiness(AddBusinessViewModel model, int VendorId)
        {
            await _adminServices.AddNewBusiness(model, VendorId);
            if (VendorId != 0)
            {
                TempData["Success"] = "Business Updated Sucessfully";
            }
            else
            {
                TempData["Success"] = "Business Addedd Sucessfully";
            }
            return RedirectToAction("Vendors");
        }

        [CustomAuthorize("Admin", "Partners")]

        public async Task<IActionResult> Partners(int VendorId)
        {
            await _adminServices.DeleteBusiness(VendorId);
            return NoContent();
        }


        [CustomAuthorize("Admin", "Location")]
        public IActionResult ProviderLocation()
        {
            return View();
        }

        [CustomAuthorize("Admin", "Location")]

        public async Task<IActionResult> GetLocation()
        {
            List<PhysicianLocation> getLocation = await _adminServices.GetPhysicianlocations();
            return Ok(getLocation);
        }

        [CustomAuthorize("Admin", "PatientHistory")]

        public IActionResult PatientHistory()
        {
            return View();
        }

        [CustomAuthorize("Admin", "PatientHistory")]

        public async Task<IActionResult> PatientHistoryData(PatientHistoryViewModel model)
        {
            var data = await _recordsServices.PatientHistory(model);
            return PartialView("_PatientHistoryData", data);
        }

        [CustomAuthorize("Admin", "PatientRecords")]

        public async Task<IActionResult> PatientRecords(int userid)
        {
            var data = await _recordsServices.PatientRecords(userid);
            return View(data);
        }

        [CustomAuthorize("Admin", "SearchRecords")]

        public IActionResult SearchRecords()
        {
            return View();
        }

        [CustomAuthorize("Admin", "SearchRecords")]

        public async Task<IActionResult> SearchRecordsData(SearchRecordsViewModel model)
        {
            var data = await _recordsServices.SearchRecords(model);
            return PartialView("_SearchRecordsData", data);
        }

        [CustomAuthorize("Admin", "SearchRecords")]

        public async Task<IActionResult> DeleteRecord(int RequestId)
        {
            await _recordsServices.DeleteRecord(RequestId);
            return NoContent();
        }

        [CustomAuthorize("Admin", "SearchRecords")]

        public async Task<IActionResult> ExportSearchData(SearchRecordsViewModel obj)
        {
            int CurrentPage = 0;
            int PageSize = 5;
            SearchRecordsViewModel model = new SearchRecordsViewModel();
            model = await _recordsServices.SearchRecords(obj);
            var record = await _recordsServices.DownloadExcle(model);
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            var strDate = DateTime.Now.ToString("yyyyMMdd");
            string filename = $"{model.PatientName}_{strDate}.xlsx";
            return File(record, contentType, filename);
        }

        [CustomAuthorize("Admin", "EmailLogs")]

        public async Task<IActionResult> EmailLogs()
        {
            var data = await _recordsServices.EmailLogs();
            return View(data);
        }

        [CustomAuthorize("Admin", "EmailLogs")]

        public async Task<IActionResult> EmailLogsData(LogsDataViewModel model)
        {
            var data = await _recordsServices.EmailLogsData(model);
            return PartialView("_EmailLogsData", data);
        }

        [CustomAuthorize("Admin", "SMSLogs")]

        public async Task<IActionResult> SMSLogs()
        {
            var data = await _recordsServices.EmailLogs();
            return View(data);
        }

        [CustomAuthorize("Admin", "SMSLogs")]

        public async Task<IActionResult> SMSLogsData(LogsDataViewModel model)
        {
            var data = await _recordsServices.SMSLogsData(model);
            return PartialView("_SMSLogsData", data);
        }

        [CustomAuthorize("Admin", "BlockHistory")]

        public IActionResult BlockHistory()
        {
            return View();
        }

        [CustomAuthorize("Admin", "BlockHistory")]

        public async Task<IActionResult> BlockHistoryData(BlockHistoryViewModel model)
        {
            var data = await _recordsServices.BlockHistoryData(model);
            return PartialView("_BlockHistoryData", data);
        }

        [CustomAuthorize("Admin", "BlockHistory")]

        public async Task<IActionResult> UnblockCase(int requestid)
        {
            await _recordsServices.UnblockCase(requestid);
            return NoContent();
        }
    }
}
