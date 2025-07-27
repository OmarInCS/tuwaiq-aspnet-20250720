using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ClinicDM.ViewModels {
    public class PatientFilterVM {
        public int? Id { get; set; }

        public string? FullName { get; set; }

        public string? PhoneNumber { get; set; }

    }
}
