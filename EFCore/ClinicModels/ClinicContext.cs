using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.ClinicModels {
    internal class ClinicContext : DbContext {

        public DbSet<Doctor> Doctors { get; set; } = null!;
        public DbSet<Speciality> Specialities { get; set; } = null!;

        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer("Server=localhost;Database=Clinic;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Doctor>()
                .Property(d => d.Salary)
                .HasDefaultValue(10000.0);

            //modelBuilder.Entity<Doctor>()
            //    .HasOne(d => d.Speciality)
            //    .WithMany(s => s.Doctors)
            //    .HasForeignKey(d => d.SpecialityId)
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
