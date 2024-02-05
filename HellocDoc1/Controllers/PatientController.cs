using Microsoft.AspNetCore.Mvc;

namespace HellocDoc1.Controllers
{
    public class PatientController : Controller
    {
        public IActionResult Login()
        {
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
