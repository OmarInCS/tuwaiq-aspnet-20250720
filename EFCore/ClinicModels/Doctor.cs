using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.ClinicModels {
    internal class Doctor {

        public int Id { get; set; }
        [MaxLength(150)]
        public string Name { get; set; } = null!;

        public double Salary { get; set; }

        public string? Title { get; set; }

        [ForeignKey("Speciality")]
        public int SpecId { get; set; }

        public Speciality Speciality { get; set; } = null!;
    }
}
