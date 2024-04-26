using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HellocDoc1.Controllers
{
    public class AuthController : Controller
    {
        // GET: AuthController
        public ActionResult AccessdDenied()
        {
            return View();
        }
    }
}
