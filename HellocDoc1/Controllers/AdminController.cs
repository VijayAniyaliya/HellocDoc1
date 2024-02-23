using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Models;

namespace HellocDoc1.Controllers
{
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
            model.requestCount = _adminServices.AdminDashboard().requestCount;
            return View(model);
        }


        public IActionResult NewState()
        {
            AdminDashboardViewModel model = new AdminDashboardViewModel();
            model.requestClients= _adminServices.NewState().requestClients;

            return View(model);
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
