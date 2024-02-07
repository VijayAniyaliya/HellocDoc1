using HellocDoc1.DataContext;
using HellocDoc1.DTO;
using HellocDoc1.Models;
using Microsoft.AspNetCore.Mvc;

namespace HellocDoc1.Controllers
{
    public class PatientController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public PatientController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
            var x = _applicationDbContext.AspNetUsers.Where(a => a.Email == user.Email).FirstOrDefault();
            return RedirectToAction("Index", "Home");
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
