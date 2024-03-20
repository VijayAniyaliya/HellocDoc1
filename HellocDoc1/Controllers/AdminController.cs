using Data.Entity;
using HellocDoc1.Services.Models;
using HellocDoc1.Services;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Models;
using Common.Enum;
using HelloDoc1.Services;
using Common.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using NPOI.XSSF.UserModel;

namespace HellocDoc1.Controllers
{
    [Route("[controller]/[action]")]
    [CustomAuthorize("Admin")]

    public class AdminController : Controller
    {
        private readonly IAdminServices _adminServices;

        public AdminController(IAdminServices adminServices)
        {
            _adminServices = adminServices;

        }

        public IActionResult AdminDashboard()
        {
            AdminDashboardViewModel model = new AdminDashboardViewModel();
            model = _adminServices.AdminDashboard();
            return View(model);
        }


        public IActionResult NewState(int CurrentPage=1,string patientname ="", int requesttype = 5, int PageSize = 10 )
       {
            AdminDashboardViewModel model = _adminServices.NewState(CurrentPage, patientname, requesttype, PageSize );
            return View(model);
        }
        public IActionResult PendingState(int CurrentPage = 1, string patientname = "", int requesttype = 5, int PageSize = 10)
        {
            AdminDashboardViewModel model=_adminServices.PendingState(CurrentPage, patientname, requesttype, PageSize);
            return View(model);
        }
        public IActionResult ActiveState(int CurrentPage = 1, string patientname = "", int requesttype = 5, int PageSize = 10)
        {
            AdminDashboardViewModel model = _adminServices.ActiveState(CurrentPage, patientname, requesttype, PageSize);
            return View(model);
        }
        public IActionResult ConcludeState(int CurrentPage = 1, string patientname = "", int requesttype = 5, int PageSize = 10)
        {
            AdminDashboardViewModel model = _adminServices.ConcludeState(CurrentPage, patientname, requesttype, PageSize);
            return View(model);
        }

        public IActionResult ToCloseState(int CurrentPage = 1, string patientname = "", int requesttype = 5, int PageSize = 10)
        {
            AdminDashboardViewModel model = _adminServices.ToCloseState(CurrentPage, patientname, requesttype, PageSize);
            return View(model);
        }

        public IActionResult UnpaidState(int CurrentPage = 1, string patientname = "", int requesttype = 5, int PageSize = 10)
        {
            AdminDashboardViewModel model = _adminServices.UnpaidState(CurrentPage, patientname, requesttype, PageSize);
            return View(model);
        }

        public IActionResult ViewCase(int request_id)
        {
            ViewCaseViewModel data = _adminServices.ViewCase(request_id);
            return View(data);
        }

        public IActionResult ViewNotes(int request_id)
        {
            ViewNotesViewModel data = _adminServices.ViewNotes(request_id);
            return View(data);
        }

        [Route("{request_id}")]
        public IActionResult AddNotes(ViewNotesViewModel model, int request_id)
        {
            _adminServices.AddNotes(model, request_id);
            return RedirectToAction("ViewNotes", new { request_id = request_id });
        }
        [HttpPost("{request_id}")]
        public IActionResult CancelDetails(int request_id)
        {
            CancelCaseViewModel data = _adminServices.CancelDetails(request_id);
            return PartialView("_CancelCase", data);
        }

        public async Task<IActionResult> CancelCase(int request_id, int caseId, string cancelNote)
        {
            await _adminServices.CancelCase(request_id, caseId,  cancelNote);
            return RedirectToAction("AdminDashboard");
        }

        [HttpPost("{request_id}")]
        public IActionResult AssignDetails(int request_id)
        {
            AssignCaseViewModel data = _adminServices.AssignDetails(request_id);
            return PartialView("_AssignCase", data);
        }

        public List<PhysicianSelectlViewModel> FilterData(int regionid)
        {
            List<PhysicianSelectlViewModel> data = _adminServices.FilterData(regionid);
            return data;
        }

        public async Task<IActionResult> AssignCase(int request_id, int physicianid, string description)
        {
            await _adminServices.AssignCase(request_id, physicianid, description);
            return RedirectToAction("AdminDashboard");
        }

        [HttpPost("{request_id}")]
        public IActionResult BlockDetails(int request_id)
        {
            BlockCaseViewModel data = _adminServices.BlockDetails(request_id);
            return PartialView("_BlockCase", data);
        }

        public async Task<IActionResult> BlockCase(int request_id, string reason)
        {
            await _adminServices.BlockCase(request_id, reason);
            return RedirectToAction("AdminDashboard");
        }

        public IActionResult ViewUploads(int request_id)
        {
            var model = _adminServices.ViewUploads(request_id);
            return View(model);
        }

        [HttpPost]
        public IActionResult UploadDocuments(ViewUploadsViewModel model, int request_id)
        {
            _adminServices.UploadDocuments(model, request_id);
            return RedirectToAction("ViewUploads", new { request_id = request_id });
        }

        public IActionResult Delete(int DocumentId, int RequestId)
        {
            _adminServices.Delete(DocumentId);
            return RedirectToAction("ViewUploads", new { request_id = RequestId });
        }
        public IActionResult DeleteAll([FromBody] List<int> DocumentId)
        {
            _adminServices.DeleteAll(DocumentId);
            return RedirectToAction("AdminDashboard");
        }

        public IActionResult SendMail([FromBody] List<int> DocumentId)
        {
            _adminServices.SendMail(DocumentId);
            return RedirectToAction("AdminDashboard");
            //return RedirectToAction("ViewUploads", new { request_id = RequestId });
        }

        public IActionResult SendOrders(int request_id)
        {
            var data=_adminServices.SendOders(request_id);
            return View(data);
        }

        public SendOrdersViewModel FilterDataByProfession(int ProfessionId)
        {
            SendOrdersViewModel data = _adminServices.FilterDataByProfession(ProfessionId);
            return data;
        }

        public SendOrdersViewModel FilterDataByBusiness(int BusinessId)
        {
            SendOrdersViewModel data = _adminServices.FilterDataByBusiness(BusinessId);
            return data;
        }

        [HttpPost]
        public IActionResult SendOrderDetails(SendOrdersViewModel model, int request_id, int vendorid, string contact, string email, string faxnumber)
        {
            var data = _adminServices.SendOrderDetails(model, request_id, vendorid, contact, email, faxnumber);
            return RedirectToAction("AdminDashboard");
        }

        public IActionResult TransferDetails(int request_id)
        {
            var data = _adminServices.TransferDetails(request_id);
            return PartialView("_TransferCase", data);
        }

        public async Task<IActionResult> TransferCase(int request_id, int physicianid, string description)
        {
            await _adminServices.TransferCase(request_id,  physicianid, description);
            return RedirectToAction("AdminDashboard");
        }

        public IActionResult ClearDetails(int request_id)
        {
            var data = _adminServices.ClearDetails(request_id);
            return PartialView("_ClearCase", data);
        }

        [HttpPost]
        public async Task<IActionResult> ClearCase(ClearCaseViewModel model, int request_id)
        {
            await _adminServices.ClearCase(model, request_id);
            return RedirectToAction("AdminDashboard");
        }


        public IActionResult SendAgreementDetails(int request_id)
        {
            var data = _adminServices.SendAgreementDetails(request_id);
            return PartialView("_SendAgreement", data);
        }

        [HttpPost]
        public IActionResult SendAgreement(int request_id)
        {
            string RequestId = HashingServices.Encrypt(request_id.ToString());
            _adminServices.SendAgreement( RequestId);
            return RedirectToAction("AdminDashboard");
        }
            

        public IActionResult CloseCase(int request_id)
        {
            var data=_adminServices.CloseCase(request_id);
            return View(data);
        }

        [HttpPost]
        public async Task <IActionResult> SaveCloseCase(CloseCaseViewModel model, int request_id)
        {
            await _adminServices.SaveCloseCase(model, request_id);
            return RedirectToAction("CloseCase", new { request_id });
        }


        public async Task <IActionResult> CloseCaseRequest(int request_id)
        {
            await _adminServices.CloseCaseRequest(request_id);
            return RedirectToAction("AdminDashboard");
        }

        [HttpGet]
        public IActionResult EncounterForm(int request_id)
        {
            var data = _adminServices.EncounterForm(request_id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitEncounterForm(EncounterFormViewModel model, int request_id)
        {
            await _adminServices.SubmitEncounterForm(model, request_id);
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AdminLogin()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public IActionResult AdminLogin(AdminLoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                LoginResponseViewModel? result = _adminServices.AdminLogin(user);
                if (result.Status == ResponseStatus.Success)
                {
                    Response.Cookies.Append("jwt", result.Token);
                    HttpContext.Session.SetString("Email", user.Email);
                    TempData["Success"] = "Login Successfully";
                    return RedirectToAction("AdminDashboard", "Admin");
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

        public IActionResult AdminProfile()
        {
            //var email = User.FindFirstValue(ClaimTypes.Email);
            var email = HttpContext.Session.GetString("Email");
            var data = _adminServices.ProfileData(email);
            return View(data);
        }

        public async Task <IActionResult> ResetPassword(string password)
        {
            var email = HttpContext.Session.GetString("Email");
            await _adminServices.ResetPassword(email, password);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAdminstrator(ProfileData model)
        {
            var email = HttpContext.Session.GetString("Email");
            await _adminServices.UpdateAdminstrator(model,email);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBillInfo(BillingData model)
        {
            var email = HttpContext.Session.GetString("Email");
            await _adminServices.UpdateBillInfo(model,email);
            return NoContent();
        }

        public IActionResult Provider()
        {
            var data = _adminServices.PhysicianData();
            return View(data);
        }

        public IActionResult ContactProvider(int PhysicianId)
        {
            PhysicianData physicianData =new PhysicianData();
            physicianData.physicianId= PhysicianId;
            return PartialView("_ContactProvider", physicianData);
        }

        public IActionResult SendMessage(int PhysicianId, string message)
        {
            _adminServices.SendMessage(PhysicianId,message);
            return Json("");
        }

        public IActionResult SendMailDetails()
        {
            return PartialView("_SendMail");
        }

        [HttpPost]
        public IActionResult SendLink(SendLinkViewModel model)
        {
            _adminServices.SendLink(model);
            return Json("success");
        }

        public IActionResult CreateRequest()
        {
            return View();
        }

//        public IActionResult ExportData(string requesttype, string patientname)
//        {
//                AdminDashboard data = dashboardData.AllStateData(requesttype, patientname);
//                var record = dashboardData.DownloadExcle(data);
//                string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
//                var strDate = DateTime.Now.ToString("yyyyMMdd");
//                string filename = $"{status}_{strDate}.xlsx";
//                return File(record, contentType, filename);
//        }

//        public byte[] DownloadExcle(AdminDashboard model)
//        {
//            using (var workbook = new XSSFWorkbook())
//            {
//                ISheet sheet = workbook.CreateSheet("FilteredRecord");
//                IRow headerRow = sheet.CreateRow(0);
//                headerRow.CreateCell(0).SetCellValue("Sr No.");
//                headerRow.CreateCell(1).SetCellValue("Request Id");
//                headerRow.CreateCell(2).SetCellValue("Patient Name");
//                headerRow.CreateCell(3).SetCellValue("Patient DOB");
//                headerRow.CreateCell(4).SetCellValue("RequestorName");
//                headerRow.CreateCell(5).SetCellValue("RequestedDate");
//                headerRow.CreateCell(6).SetCellValue("PatientPhone");
//                headerRow.CreateCell(7).SetCellValue("TransferNotes");
//                headerRow.CreateCell(8).SetCellValue("RequestorPhone");
//                headerRow.CreateCell(9).SetCellValue("RequestorEmail");
//                headerRow.CreateCell(10).SetCellValue("Address");
//                headerRow.CreateCell(11).SetCellValue("Notes");
//                headerRow.CreateCell(12).SetCellValue("ProviderEmail");
//                headerRow.CreateCell(13).SetCellValue("PatientEmail");
//                headerRow.CreateCell(14).SetCellValue("RequestType");
//                //headerRow.CreateCell(15).SetCellValue("Region");
//                headerRow.CreateCell(16).SetCellValue("PhysicainName");
//                headerRow.CreateCell(17).SetCellValue("Status");

//                for (int i = 0; i < model.requestclients.Count; i++)
//                {
//                    var reqclient = model.requestclients.ElementAt(i);
//                    var type = "";
//                    if (reqclient.Request.Requesttypeid == 1)
//                    {
//                        type = "Patient";
//                    }
//                    else if (reqclient.Request.Requesttypeid == 2)
//                    {
//                        type = "Family";
//                    }
//                    else if (reqclient.Request.Requesttypeid == 4)
//                    {
//                        type = "Business";
//                    }
//                    else if (reqclient.Request.Requesttypeid == 3)
//                    {
//                        type = "Concierge";
//                    }
//                    IRow row = sheet.CreateRow(i + 1);
//                    row.CreateCell(0).SetCellValue(i + 1);
//                    row.CreateCell(1).SetCellValue(reqclient.Request.Requestid);
//                    row.CreateCell(2).SetCellValue(reqclient.Firstname);
//                    row.CreateCell(3).SetCellValue(reqclient.Intdate + "/" + reqclient.Strmonth + "/" + reqclient.Intyear);
//                    row.CreateCell(4).SetCellValue(reqclient.Request.Firstname);
//                    row.CreateCell(5).SetCellValue(reqclient.Request.Createddate);
//                    row.CreateCell(6).SetCellValue(reqclient.Phonenumber);
//                    if (reqclient.Request.Requeststatuslogs.Count() == 0)
//                    {
//                        row.CreateCell(7).SetCellValue("");
//                    }
//                    else
//                    {
//                        row.CreateCell(7).SetCellValue(reqclient.Request.Requeststatuslogs.ElementAt(0).Notes);
//                    }
//                    row.CreateCell(8).SetCellValue(reqclient.Request.Phonenumber);
//                    row.CreateCell(9).SetCellValue(reqclient.Request.Email);
//                    row.CreateCell(10).SetCellValue(reqclient.Request.Requestclients.ElementAt(0).Address);
//                    row.CreateCell(11).SetCellValue(reqclient.Notes);
//                    if (reqclient.Request.Physician == null)
//                    {
//                        row.CreateCell(12).SetCellValue("");
//                    }
//                    else
//                    {
//                        row.CreateCell(12).SetCellValue(reqclient.Request.Physician.Email);
//                    }
//                    row.CreateCell(13).SetCellValue(reqclient.Email);
//                    row.CreateCell(14).SetCellValue(type);
//                    //row.CreateCell(15).SetCellValue(reqclient.Region.Name);
//                    if (reqclient.Request.Physician == null)
//                    {
//                        row.CreateCell(16).SetCellValue("");
//                    }
//                    else
//                    {
//                        row.CreateCell(16).SetCellValue(reqclient.Request.Physician.Firstname);
//                    }
//                    row.CreateCell(17).SetCellValue(reqclient.Request.Status);
//                }

//                using (var stream = new MemoryStream())
//                {
//                    workbook.Write(stream)
//;
//                    var content = stream.ToArray();
//                    return content;
//                }
//            }
//        }

        [HttpPost]
        public async Task<IActionResult> CreateRequest(CreateRequestViewModel model)
        {
            await _adminServices.SubmitRequest(model);
            return RedirectToAction("AdminDashboard");
        }

        public IActionResult PhysicianAccount()
        {
            return View();
        }
    }
}
