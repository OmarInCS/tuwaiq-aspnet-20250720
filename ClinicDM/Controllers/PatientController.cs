using ClinicDM.Models;
using ClinicDM.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ClinicDM.Controllers {
    public class PatientController : Controller {


        public IActionResult Index() {
            var patients = Constants.Patients.Select(p => p.ToPatientVM()).ToList();
            return View(patients);
        }

        public IActionResult Details(int id) {

           var patient = Constants.Patients.FirstOrDefault(p => p.Id == id);
            if (patient == null) {
                return NotFound();
            }

            var vm = patient.ToPatientVM();
            return View(vm);
        }


        public IActionResult Create() {
            var vm = new PatientCreateVM();
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(PatientCreateVM newPatient) {

            if(!ModelState.IsValid) {
                return View(newPatient);
            }

            var patient = newPatient.ToPatient();
            Constants.Patients.Add(patient);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int id) {
            var patient = Constants.Patients.FirstOrDefault(p => p.Id == id);
            if (patient == null) {
                return NotFound();
            }
            
            var vm = patient.ToPatientUpdateVM();
            return View(vm);
        }

        [HttpPost]
        public IActionResult Update(int id, PatientUpdateVM updatedPatient) {

            if (!ModelState.IsValid) {
                return View(updatedPatient);
            }

            var existingPatient = Constants.Patients.FirstOrDefault(p => p.Id == id);
            if (existingPatient == null) {
                return NotFound();
            }

            updatedPatient.ToPatient(existingPatient);
            return RedirectToAction(nameof(Index));
        }
    }
}
