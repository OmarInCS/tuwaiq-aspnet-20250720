using ClinicDM.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClinicDM.Controllers {
    public class PatientController : Controller {


        public IActionResult Index() {
            return View(Constants.Patients);
        }

        public IActionResult Details(int id) {

           var patient = Constants.Patients.FirstOrDefault(p => p.Id == id);
            if (patient == null) {
                return NotFound();
            }
            return View(patient);
        }
    }
}
