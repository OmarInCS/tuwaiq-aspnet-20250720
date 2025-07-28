using ClinicDM.Helpers;
using ClinicDM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.ClinicModels {
    public class ClinicContext : DbContext {

        public DbSet<Doctor> Doctors { get; set; } = null!;
        public DbSet<Patient> Patients { get; set; } = null!;
        public DbSet<Appointment> Appointments { get; set; } = null!;


        public ClinicContext(DbContextOptions options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Appointment>()
                .Property(x => x.CreationDate)
                .HasDefaultValueSql("GetDate()");

            modelBuilder.Entity<Doctor>()
                .HasData(
                    new Doctor { Id = 1, Name = "Wael Osama"}
                );

            modelBuilder.Entity<Appointment>()
                .HasData(
                    new Appointment { Id = 1, AppointmentDate =  new DateTime(2025, 8, 1, 17, 0, 0), DoctorId = 1, PatientId = 1, Status = "Scheduled" },
                    new Appointment { Id = 2, AppointmentDate = new DateTime(2025, 7, 25, 17, 0, 0), DoctorId = 1, PatientId = 1, Status = "Completed" },
                    new Appointment { Id = 3, AppointmentDate =  new DateTime(2025, 8, 5, 17, 0, 0), DoctorId = 1, PatientId = 1, Status = "Scheduled" }
                );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
