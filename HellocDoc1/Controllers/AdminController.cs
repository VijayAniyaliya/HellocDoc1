﻿using Data.Entity;
using HellocDoc1.Services.Models;
using HellocDoc1.Services;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Models;
using Common.Enum;
using HelloDoc1.Services;
using BusinessLogic.Services;
using Common.Helpers;

namespace HellocDoc1.Controllers
{
    [Route("[controller]/[action]")]
    public class AdminController : Controller
    {
        private readonly IJwtService _jwtService;
        private readonly IAdminServices _adminServices;

        public AdminController(IAdminServices adminServices, IJwtService jwtService)
        {
            _adminServices = adminServices;

            _jwtService = jwtService;

        }

        public IActionResult AdminDashboard()
        {
            AdminDashboardViewModel model = new AdminDashboardViewModel();
            model = _adminServices.AdminDashboard();
            return View(model);
        }


        public IActionResult NewState()
        {
            AdminDashboardViewModel model = new AdminDashboardViewModel();
            model.requestClients = _adminServices.NewState().requestClients;

            return View(model);
        }
        public IActionResult PendingState()
        {
            AdminDashboardViewModel model = new AdminDashboardViewModel();
            model.requestClients = _adminServices.PendingState();
            return View(model);
        }
        public IActionResult ActiveState()
        {
            AdminDashboardViewModel model = new AdminDashboardViewModel();
            model.requestClients = _adminServices.ActiveState();
            return View(model);
        }
        public IActionResult ConcludeState()
        {
            AdminDashboardViewModel model = new AdminDashboardViewModel();
            model.requestClients = _adminServices.ConcludeState();
            return View(model);
        }

        public IActionResult ToCloseState()
        {
            AdminDashboardViewModel model = new AdminDashboardViewModel();
            model.requestClients = _adminServices.ToCloseState();
            return View(model);
        }

        public IActionResult UnpaidState()
        {
            AdminDashboardViewModel model = new AdminDashboardViewModel();
            model.requestClients = _adminServices.UnpaidState();
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

        [HttpPost]
        public async Task<IActionResult> CancelCase(CancelCaseViewModel model, [FromForm] int request_id)
        {
            await _adminServices.CancelCase(model, request_id);
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

        [HttpPost]
        public async Task<IActionResult> AssignCase(AssignCaseViewModel model, [FromForm] int request_id)
        {
            await _adminServices.AssignCase(model, request_id);
            return RedirectToAction("AdminDashboard");
        }

        [HttpPost("{request_id}")]
        public IActionResult BlockDetails(int request_id)
        {
            BlockCaseViewModel data = _adminServices.BlockDetails(request_id);
            return PartialView("_BlockCase", data);
        }

        [HttpPost]
        public async Task<IActionResult> BlockCase(BlockCaseViewModel model, [FromForm] int request_id)
        {
            await _adminServices.BlockCase(model, request_id);
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
            //return RedirectToAction("ViewUploads", new { request_id = RequestId });
        }

        public IActionResult SendMail([FromBody] List<int> DocumentId)
        {
            _adminServices.SendMail(DocumentId);
            return RedirectToAction("AdminDashboard");
            //return RedirectToAction("ViewUploads", new { request_id = RequestId });
        }

        public IActionResult SendOrders()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AdminLogin()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
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
