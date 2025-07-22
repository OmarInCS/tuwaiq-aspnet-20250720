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




// ------------------------------------------

var hrContext = new HrContext();
var employees = hrContext.Employees
    .Where(e => e.DepartmentId == 30)
    .Select(e => new {
        Name = e.FirstName + " " + e.LastName,
        Salary = e.Salary,
        DepartmentId = e.DepartmentId,
        HireDate = e.HireDate
    })
    .ToList();

//var emps = from e in hrContext.Employees
//           where e.DepartmentId == 30
//           select new {
//               Name = e.FirstName + " " + e.LastName,
//               Salary = e.Salary,
//               DepartmentId = e.DepartmentId,
//               HireDate = e.HireDate
//           };

Console.WriteLine(employees);


// ------------------------------------------

// Lazy Loading
var employees2 = hrContext.Employees
    .Select(e => new {
        Name = e.FirstName + " " + e.LastName,
        Department = e.Department.DepartmentName,
        City = e.Department.Location.City,
    })
    .ToList();

Console.WriteLine(employees2);

// ------------------------------------------

// Eager Loading with Include and ThenInclude
var employees3 = hrContext.Employees
    .Include(e => e.Department)
    .ThenInclude(d => d.Location)
    .Select(e => new {
        Name = e.FirstName + " " + e.LastName,
        Department = e.Department.DepartmentName,
        City = e.Department.Location.City,
    })
    .ToList();

Console.WriteLine(employees3);


// ------------------------------------------

var employees4 = hrContext.Employees
    .GroupBy(e => e.JobId)
    .Select(g => new {
        Job = g.Key,
        AverageSalary = Convert.ToInt32(g.Average(e => e.Salary)),
    })
    .ToList();

Console.WriteLine(employees4);



// ------------------------------------------

var numbers = new List<int> { 1, 2, 3, 4, 5 };
var numG3 = numbers
    .Where(n => n > 3)
    .ToList();

var numG2 = from n in numbers
            where n > 2
            select n;

Console.WriteLine(numG3);






