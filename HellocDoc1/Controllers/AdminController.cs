using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Models;

namespace HellocDoc1.Controllers
{
    [Route("[controller]/[action]")]
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
            model = _adminServices.AdminDashboard();
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
            AdminDashboardViewModel model= new AdminDashboardViewModel();
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
            ViewCaseViewModel data= _adminServices.ViewCase(request_id);
            return View(data);
        }

        public IActionResult ViewNotes(int request_id)
        {
            ViewNotesViewModel data= _adminServices.ViewNotes(request_id);
            return View(data);
        }

        [Route("{request_id}")]
        public IActionResult AddNotes(ViewNotesViewModel model, int request_id)
        {
            _adminServices.AddNotes(model, request_id);
            return RedirectToAction("ViewNotes",new {request_id=request_id});
        }
    }
}
