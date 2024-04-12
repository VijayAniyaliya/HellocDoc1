using Common.Helpers;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Implementation;
using Services.Models;

namespace HellocDoc1.Controllers
{
    [Route("[controller]/[action]")]
    [CustomAuthorize("Physician")]
    public class ProviderController : Controller
    {
        private readonly IProviderServices _providerServices;

        public ProviderController(IProviderServices providerServices)
        {
            _providerServices = providerServices;

        }

        public async Task<IActionResult> ProviderDashboard()
        {
            var data = await _providerServices.ProviderDashboard();
            return View(data);
        }

        public async Task<IActionResult> NewState(AdminDashboardViewModel obj)
        {
            var data = await _providerServices.NewState(obj);
            return PartialView("_NewState",data);
        }

        public async Task<IActionResult> PendingState(AdminDashboardViewModel obj)
        {
            var data = await _providerServices.PendingState(obj);
            return PartialView("_NewState", data);
        }
        public async Task<IActionResult> ActiveState(AdminDashboardViewModel obj)
        {
            var data = await _providerServices.ActiveState(obj);
            return PartialView("_NewState", data);
        }
        public async Task<IActionResult> ConcludeState(AdminDashboardViewModel obj)
        {
            var data = await _providerServices.ConcludeState(obj);
            return PartialView("_NewState", data);
        }
    }
}
