// See https://aka.ms/new-console-template for more information

using EFCore.ClinicModels;
using EFCore.HrModels;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

var context = new HrContext();

var numOfEmps = context.Employees.Count();
Console.WriteLine("Num of Employees: " + numOfEmps);

var emps = context.Employees.Where(e => e.Salary >= 15000);
foreach (var emp in emps)
{
    Console.WriteLine($"Employee: {emp.FirstName} {emp.LastName}, Salary: {emp.Salary}");
}

// Insert
var clinicContext = new ClinicContext();
var newDoctor = new Doctor {
    Name = "Dr. Smith",
    Salary = 12000,
    Title = "Cardiologist",
    SpecId = 1 // Assuming 1 is a valid Speciality Id
};

clinicContext.Doctors.Add(newDoctor);
clinicContext.SaveChanges();


// Update
//var doctor = clinicContext.Doctors.First();
//doctor.Salary = 15000; // Update salary
//clinicContext.SaveChanges();


// Delete
//var doctor = clinicContext.Doctors.First();
//clinicContext.Doctors.Remove(doctor);
//clinicContext.SaveChanges();


clinicContext.Doctors
    .Where(d => d.Name == "Dr. Smith")
    .ExecuteUpdate(d => d.SetProperty(d => d.Name, "Omar"));








