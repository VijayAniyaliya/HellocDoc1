using HellocDoc1.DataContext;
using HellocDoc1.DTO;
using HellocDoc1.Models;
using HellocDoc1.Services;
using HelloDoc1.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace HellocDoc1.Controllers
{
    public class PatientController : Controller
    {
        private readonly ILoginHandler loginHandler;
        private readonly IPatientRequest patientRequest;
        private readonly IFamilyRequest familyRequest;
        private readonly IConcirgeRequest concirgeRequest;
        private readonly IBusinessRequest businessRequest;

        public PatientController(ILoginHandler loginHandler, IPatientRequest patientRequest, IFamilyRequest familyRequest, IConcirgeRequest concirgeRequest, IBusinessRequest businessRequest)
        {
            this.loginHandler = loginHandler;
            this.patientRequest = patientRequest;
            this.familyRequest = familyRequest;
            this.concirgeRequest = concirgeRequest;
            this.businessRequest = businessRequest;
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
                IdentityResult? result = loginHandler.Login(user);
            if (result.Succeeded)
            {
            return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", result.Errors.First().Description);
                return View();

            }
            }
            return View();

        }


        public IActionResult Reset_password()
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

        //private readonly ILoginHandler loginHandler;

        //public PatientController(ILoginHandler loginHandler)
        //{
        //    this.loginHandler = loginHandler;
        //}

        public IActionResult Patient_request()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Patient_request(PatientRequestModel model)
        {
            if(ModelState.IsValid)
            {
                patientRequest.Patient_request(model);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult Family_request()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Family_request(FamilyRequestModel model)
        {
            if (ModelState.IsValid)
            {
                familyRequest.Family_request(model);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult Concierge_request()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Concierge_request(ConciergeRequestModel model)
        {
            if (ModelState.IsValid)
            {
                concirgeRequest.Concierge_request(model);
                return RedirectToAction("Index", "Home");   
            }
            return View();
        }

        public IActionResult Business_request()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Business_request(BusinessRequestModel model)
        {
            if (ModelState.IsValid)
            {
                businessRequest.Business_request(model);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult Patient_Dashboard()
        {
            return View();
        }
    }
}
