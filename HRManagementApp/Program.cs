// See https://aka.ms/new-console-template for more information
using HRManagementApp.Models;
using HRManagementApp.Services;

Console.WriteLine("Hello, World!");
Employee e1 = new("Smr", "Hac", 1000, "IT");
Employee e2 = new("Aysel", "QA", 1200, "HR");
Employee e3 = new("Murad", "Dev", 1500, "IT");
Employee e4 = new("Nigar", "Design", 1100, "Marketing");
Employee e5 = new("Elvin", "Support", 900, "Support");

Console.WriteLine(e1);
Console.WriteLine(e2);
Console.WriteLine(e3);
Console.WriteLine(e4);
Console.WriteLine(e5);

HumanResourceManager humanResourceManager = new HumanResourceManager();



humanResourceManager.AddDepartment("IT", 15, 10000);
humanResourceManager.AddEmployee("Smr", "Hac", 1000, humanResourceManager.Departments[0].Name);