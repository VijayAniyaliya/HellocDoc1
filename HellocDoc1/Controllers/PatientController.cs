using Common.Enum;
using Data.Context;
using Data.Entity;
using HellocDoc1.Services;
using HellocDoc1.Services.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using Services.Contracts;
using Services.Models;

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
        private readonly ApplicationDbContext _context;

        public PatientController(ILoginHandler loginHandler, IPatientRequest patientRequest, IFamilyRequest familyRequest, IConcirgeRequest concirgeRequest, IBusinessRequest businessRequest, IPatientServices patientServices, ApplicationDbContext context)
        {
            this.loginHandler = loginHandler;
            this.patientRequest = patientRequest;
            this.familyRequest = familyRequest;
            this.concirgeRequest = concirgeRequest;
            this.businessRequest = businessRequest;
            this.patientServices = patientServices;
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                LoginResponseViewModel? result = loginHandler.Login(user);
                if (result.Status == ResponseStatus.Success)
                {
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
        public IActionResult Reset_password(AspNetUser user)
        {
            var aspuser = _context.AspNetUsers.FirstOrDefault(x => x.Email == user.Email);
            if (aspuser != null)
            {
                patientServices.ResetPassword(aspuser.Email);
            }

            return RedirectToAction("Login", "Patient");
        }

        [HttpGet("[controller]/[action]/{email}")]
        public IActionResult ChangePassword(string email)
        {
            ViewBag.Email = email;
            return View();
        }
        [HttpPost]
        public IActionResult ChangePassword(ChangePassViewModel model)
        {
            patientServices.ChangePassword(model.Email, model);
            return View();
        }

        public IActionResult CreatePatientAccount()
        {
            return View();
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Patient_request(PatientRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await patientRequest.Patient_request(model);
                return RedirectToAction("Submit_request", "Patient");
            }
            return View();
        }

        [Route("/Patient/Patient_request/checkmail/{email}")]
        [HttpGet]
        public IActionResult CheckEmail(string email)
        {
            var emailExists = _context.AspNetUsers.Any(u => u.Email == email);
            return Json(new { exists = emailExists });
        }

        public IActionResult Family_request()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Family_request(FamilyRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await familyRequest.Family_request(model);
                return RedirectToAction("Submit_request", "Patient");
            }
            return View();
        }

        public IActionResult Concierge_request()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Concierge_request(ConciergeRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await concirgeRequest.Concierge_request(model);
                return RedirectToAction("Submit_request", "Patient");
            }
            return View();
        }

        public IActionResult Business_request()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Business_request(BusinessRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await businessRequest.Business_request(model);
                return RedirectToAction("Submit_request", "Patient");
            }
            return View();
        }

        public IActionResult SubmitInformationMe()
        {
            return View();
        }   

        public IActionResult SubmitInformationSomeone(SubmitInfoViewModel model)
        {
            if (ModelState.IsValid)
            {
                patientServices.SubmitInformationSomeone(model);
                return RedirectToAction("Patient_Dashboard", "Patient");
            }
            return View();
        }


        public IActionResult Patient_Dashboard()
        {
            var email = HttpContext.Session.GetString("Email");
            var data = patientServices.DashboardService(email);

            return View(data);
        }

        public IActionResult Patient_Document(int request_id)
        {
            var data = patientServices.DocumentService(request_id);
            return View(data);
        }

        [HttpPost]
        public IActionResult UploadDocument(PatientServiceModel model,int request_id)
        {
            patientServices.UploadDocument(model,request_id);
            return RedirectToAction("Patient_Document", new {request_id=request_id});
        }


        public async Task<IActionResult> DownloadAll(int request_id)
        {
            var download = await patientServices.DownloadFilesForRequest(request_id);
            return File(download, "application/zip", "RequestFiles.zip");
        }



        public IActionResult Patient_Profile()
        {
            var email = HttpContext.Session.GetString("Email");
            var data = patientServices.ProfileService(email);
            return View(data);
        }

        public IActionResult Editing(User model)
        {
            var email = HttpContext.Session.GetString("Email");
            patientServices.Editing(email, model);
            return RedirectToAction("Patient_Profile", "Patient");
        }

        public IActionResult ReviewAgreement()
        {
            return View();
        }
    }
}


