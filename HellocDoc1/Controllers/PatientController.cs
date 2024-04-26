﻿using Common.Enum;
using Common.Helpers;
using Data.Context;
using Data.Entity;
using HellocDoc1.Services.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Models;
using System.Security.Claims;

namespace HellocDoc1.Controllers
{
    public class PatientController : Controller
    {
        private readonly ILoginHandler loginHandler;
        private readonly IPatientRequest patientRequest;
        private readonly IFamilyRequest familyRequest;
        private readonly IConcirgeRequest concirgeRequest;
        private readonly IBusinessRequest businessRequest;
        private readonly IPatientServices patientServices;

        public PatientController(ILoginHandler loginHandler, IPatientRequest patientRequest, IFamilyRequest familyRequest, IConcirgeRequest concirgeRequest, IBusinessRequest businessRequest, IPatientServices patientServices)
        {
            this.loginHandler = loginHandler;
            this.patientRequest = patientRequest;
            this.familyRequest = familyRequest;
            this.concirgeRequest = concirgeRequest;
            this.businessRequest = businessRequest;
            this.patientServices = patientServices;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                LoginResponseViewModel? result = await loginHandler.Login(user);
                if (result.Status == ResponseStatus.Success)
                {
                    Response.Cookies.Append("jwt", result.Token);
                    HttpContext.Session.SetString("Email", user.Email);
                    TempData["Success"] = "Login Successfully";
                    return RedirectToAction("Patient_Dashboard", "Patient");
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
            HttpContext.Session.Remove("Email");

            return RedirectToAction("Login", "Patient");
        }

        public IActionResult Reset_password()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Reset_password(LoginViewModel model)
        {
            LoginResponseViewModel? result = await patientServices.ResetPassword(model);
            if (result.Status == ResponseStatus.Success)
            {
                return RedirectToAction("Login", "Patient");
            }
            else
            {
                ModelState.AddModelError("", result.Message);
                TempData["Error"] = result.Message;
                return View();
            }
        }

        [HttpGet("[controller]/[action]/{email}")]
        public IActionResult ChangePassword(string email)
        {
            string Email = HashingServices.Decrypt(email);
            ViewBag.Email = Email;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePassViewModel model)
        {
            await patientServices.ChangePassword(model.Email, model);
            return RedirectToAction("Login", "Patient");
        }


        [HttpGet("[controller]/[action]/{request_id}")]
        public IActionResult CreatePatientAccount(string request_id)
        {
            int requestId = int.Parse(HashingServices.Decrypt(request_id));
            CreateAccountViewModel model = new CreateAccountViewModel()
            {
                RequestId = requestId,
            };
            return View(model);
        }

        public async Task<IActionResult> CreatePatientAccount(CreateAccountViewModel model)
        {
            LoginResponseViewModel? result = await loginHandler.CreateNewAccount(model);
            if (result.Status == ResponseStatus.Success)
            {
                TempData["Success"] = "Account Created Successfully";
                return RedirectToAction("Login", "Patient");
            }
            else
            {
                CreateAccountViewModel model1 = new CreateAccountViewModel()
                {
                    RequestId = model.RequestId,
                };
                ModelState.AddModelError("", result.Message);
                TempData["Error"] = result.Message;
                return View(model1);
            }
        }


        public IActionResult Submit_request()
        {
            return View();
        }


        public IActionResult Submit_request_screen()
        {
            return View();
        }

        public IActionResult Patient_request()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Patient_request(PatientRequestModel model)
        {
            await patientRequest.Patient_request(model);
            return RedirectToAction("Submit_request", "Patient");
        }

        [Route("/Patient/Patient_request/checkmail/{email}")]
        [HttpGet]
        public async Task<bool> CheckEmail(string email)
        {
            User user = await patientServices.CheckEmail(email);

            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IActionResult Family_request()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Family_request(FamilyRequestModel model)
        {
            await familyRequest.Family_request(model);
            return RedirectToAction("Submit_request", "Patient");
        }

        public IActionResult Concierge_request()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Concierge_request(ConciergeRequestModel model)
        {
            await concirgeRequest.Concierge_request(model);
            return RedirectToAction("Submit_request", "Patient");
        }

        public IActionResult Business_request()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Business_request(BusinessRequestModel model)
        {
            await businessRequest.Business_request(model);
            return RedirectToAction("Submit_request", "Patient");
        }

        [CustomAuthorize("User")]

        public async Task<IActionResult> SubmitInformationMe()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var data = await patientServices.SubmitInformationMe(email);
            return View(data);
        }

        public IActionResult SubmitInformationSomeone()
        {
            return View();
        }
        public async Task<IActionResult> SubmitInformationSomeoneelse(SubmitInfoViewModel model)
        {
            if (ModelState.IsValid)
            {
                await patientServices.SubmitInformationSomeone(model);
                return RedirectToAction("Patient_Dashboard", "Patient");
            }
            return View();
        }

        [CustomAuthorize("User")]

        public IActionResult Patient_Dashboard()
        {
            return View();
        }

        [CustomAuthorize("User")]

        public async Task<IActionResult> DashboardData(int requestedPage)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var data = await patientServices.DashboardData(requestedPage, email);
            return PartialView("_DashboardData", data);
        }

        [CustomAuthorize("User")]
        public async Task<IActionResult> Patient_Document(int request_id)
        {
            var data = await patientServices.DocumentService(request_id);
            return View(data);
        }

        [CustomAuthorize("User")]
        [HttpPost]
        public async Task<IActionResult> UploadDocument(PatientServiceModel model, int request_id)
        {
            await patientServices.UploadDocument(model, request_id);
            return RedirectToAction("Patient_Document", new { request_id = request_id });
        }

        [CustomAuthorize("User")]

        public async Task<IActionResult> DownloadAll(int request_id)
        {
            var download = await patientServices.DownloadFilesForRequest(request_id);
            return File(download, "application/zip", "RequestFiles.zip");
        }


        [CustomAuthorize("User")]

        public async Task<IActionResult> Patient_Profile()
        {
            var email = HttpContext.Session.GetString("Email");
            var data = await patientServices.ProfileService(email);
            return View(data);
        }

        [CustomAuthorize("User")]
        public async Task<IActionResult> Editing(ProfileViewModel model)
        {
            var email = HttpContext.Session.GetString("Email");
            await patientServices.Editing(email, model);
            return RedirectToAction("Patient_Profile", "Patient");
        }

        [CustomAuthorize("User")]
        [HttpGet("[controller]/[action]/{request_id}")]
        public async Task<IActionResult> ReviewAgreement(string request_id)
        {
            string RequestId = HashingServices.Decrypt(request_id);
            var data = await patientServices.ReviewAgreement(RequestId);
            return View(data);
        }

        public async Task<IActionResult> AcceptAgreement(int request_id)
        {
            await patientServices.AcceptAgreement(request_id);
            return NoContent();
        }

        public async Task<IActionResult> CancelAgreement(int request_id, string reason)
        {
            await patientServices.CancelAgreement(request_id, reason);
            return RedirectToAction("AdminDashboard");
        }


    }
}


