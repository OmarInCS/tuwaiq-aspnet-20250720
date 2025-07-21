// See https://aka.ms/new-console-template for more information

using EFCore.HrModels;

Console.WriteLine("Hello, World!");

var context = new HrContext();

var numOfEmps = context.Employees.Count();
Console.WriteLine("Num of Employees: " + numOfEmps);

var emps = context.Employees.Where(e => e.Salary >= 15000);
foreach (var emp in emps)
{
    Console.WriteLine($"Employee: {emp.FirstName} {emp.LastName}, Salary: {emp.Salary}");
}




