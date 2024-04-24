using Assignments.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Model;
using System.Diagnostics;

namespace Assignments.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPatientServices _patientServices;

        public HomeController(ILogger<HomeController> logger, IPatientServices patientServices)
        {
            _logger = logger;
            _patientServices = patientServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult PatientForm()
        {
            return PartialView("_PatientForm");
        }

        public IActionResult EditPatientForm(int PatientId)
        {
            var data = _patientServices.EditPatientForm(PatientId);
            return PartialView("_EditPatientData", data);
        }

        public IActionResult SubmitPatientForm(PatientFormViewModel model, int gender)
        {
            _patientServices.SubmitPatientForm(model, gender);
            TempData["Success"] = "Patient Created Succefully";
            return RedirectToAction("Index");
        }

        public IActionResult EditPatientData(PatientFormViewModel model, int gender)
        {
            _patientServices.EditPatientData(model, gender);
            TempData["Success"] = "Record Updated Succefully";
            return RedirectToAction("Index");
        }

        public IActionResult PatientData(PatientTableViewModel model)
        {
            var data = _patientServices.PatientData(model);
            return PartialView("_PatientData", data);
        }

        public IActionResult DeleteRecord(int PatientId)
        {
            _patientServices.DeleteRecord(PatientId);
            return NoContent();
        }
    }
}