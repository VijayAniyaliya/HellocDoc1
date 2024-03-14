﻿using Data.Entity;
using HellocDoc1.Services.Models;
using HellocDoc1.Services;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Models;
using Common.Enum;
using HelloDoc1.Services;
using Common.Helpers;
using Microsoft.AspNetCore.Authorization;

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
        public IActionResult SendAgreement(SendAgreementViewModel model, int request_id)
        {
            _adminServices.SendAgreement(model, request_id);
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

        public IActionResult CancelChanges(int request_id)
        {
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


    }
}
