using ClinicDM.Models;
using ClinicDM.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ClinicDM.Controllers {
    public class PatientController : Controller {


        public IActionResult Index() {
            var patients = Constants.Patients.Select(p => new PatientVM {
                Id = p.Id,
                FullName = p.FullName,
                DateOfBirth = p.DateOfBirth,
                Email = p.Email,
                NationalId = p.NationalId,
                PhoneNumber = p.PhoneNumber
            }).ToList();
            return View(patients);
        }

        public IActionResult Details(int id) {

           var patient = Constants.Patients.FirstOrDefault(p => p.Id == id);
            if (patient == null) {
                return NotFound();
            }
            return View(patient);
        }


        public IActionResult Create() {
            var patient = new Patient();
            return View(patient);
        }

        [HttpPost]
        public IActionResult Create(Patient newP) {

            if(!ModelState.IsValid) {
                return View(newP);
            }

            Constants.Patients.Add(newP);
            return RedirectToAction(nameof(Index));
        }
    }
}
