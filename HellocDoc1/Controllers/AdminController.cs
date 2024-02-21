using Microsoft.AspNetCore.Mvc;

namespace HellocDoc1.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult AdminDashboard()
        {
            return View();
        }
    }
}
