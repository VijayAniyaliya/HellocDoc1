using Microsoft.AspNetCore.Mvc;

namespace HellocDoc1.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult AdminDashboard()
        {
            return View();
        }

        public IActionResult NewState()
        {
            return View();
        }
        public IActionResult PendingState()
        {
            return View();
        }
        public IActionResult ActiveState()
        {
            return View();
        }
        public IActionResult ConcludeState()
        {
            return View();
        }

        public IActionResult ToCloseState()
        {
            return View();
        }

        public IActionResult UnpaidState()
        {
            return View();
        }
    }
}
