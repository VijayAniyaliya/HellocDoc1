using HellocDoc1.DataContext;
using HellocDoc1.DTO;
using HellocDoc1.Models;
using HellocDoc1.Services;
using HelloDoc1.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HellocDoc1.Controllers
{
    public class PatientController : Controller
    {
        private readonly ILoginHandler loginHandler;

        public PatientController(ILoginHandler loginHandler)
        {
            this.loginHandler = loginHandler;
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

        public IActionResult Patient_request()
        {
            return View();
        }

        public IActionResult Family_request()
        {
            return View();
        }

        public IActionResult Concierge_request()
        {
            return View();
        }

        public IActionResult Business_request()
        {
            return View();
        }
    }
}
