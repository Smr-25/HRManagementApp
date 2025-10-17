// See https://aka.ms/new-console-template for more information
using HRManagementApp.Models;
using HRManagementApp.Services;

//Console.WriteLine("Hello, World!");
//Employee e1 = new("Smr", "Hac", 4000, "IT");
//Employee e2 = new("Aysel", "QA", 5000, "HR");
//Employee e3 = new("Murad", "Dev", 1000, "IT");
//Employee e4 = new("Nigar", "Design", 1100, "Marketing");
//Employee e5 = new("Elvin", "Support", 900, "Support");

// Console.WriteLine(e1);
// Console.WriteLine(e2);
// Console.WriteLine(e3);
// Console.WriteLine(e4);
// Console.WriteLine(e5);

HumanResourceManager humanResourceManager = new HumanResourceManager();



//humanResourceManager.AddDepartment("IT", 3, 10000);
//humanResourceManager.AddDepartment("HR", 10, 7000);
//humanResourceManager.AddDepartment("Marketing", 8, 5000);
//humanResourceManager.AddDepartment("Support", 5, 3000);
//humanResourceManager.AddEmployee("Smr", "Hac", 1000, humanResourceManager.Departments[0].Name);
//humanResourceManager.AddEmployee("Murad", "Dev", 1500, humanResourceManager.Departments[0].Name);
//humanResourceManager.AddEmployee("Aysel", "QA", 1200, "IT");
//humanResourceManager.AddEmployee("Nigar", "Design", 1100, "IT");
//humanResourceManager.AddEmployee("Elvin", "Support", 900, "IT");

//humanResourceManager.GetDepartments();
//humanResourceManager.AddEmployee(e1.FullName, e1.Position, e1.Salary, e1.DepartmentName);
//humanResourceManager.AddEmployee(e3.FullName, e3.Position, e1.Salary, e1.DepartmentName);
//humanResourceManager.AddEmployee(e4.FullName, e4.Position, e4.Salary, e1.DepartmentName);
//humanResourceManager.AddEmployee(e5.FullName, e5.Position, e5.Salary, e1.DepartmentName);




// Departamentləri əlavə et
humanResourceManager.AddDepartment("IT", 3, 10000);
humanResourceManager.AddDepartment("HR", 3, 7000);
humanResourceManager.AddDepartment("Marketing", 3, 5000);

// IT departamentinə 3 işçi əlavə et
humanResourceManager.AddEmployee("Aysel", "QA", 1200, "IT");
humanResourceManager.AddEmployee("Nigar", "Dev", 1100, "IT");
humanResourceManager.AddEmployee("Elvin", "Support", 900, "IT");

// HR departamentinə 3 işçi əlavə et
humanResourceManager.AddEmployee("Samir", "HR Manager", 2000, "HR");
humanResourceManager.AddEmployee("Leyla", "Recruiter", 1500, "HR");
humanResourceManager.AddEmployee("Murad", "Assistant", 1200, "HR");

// Marketing departamentinə 3 işçi əlavə et
humanResourceManager.AddEmployee("Rauf", "Designer", 1300, "Marketing");
humanResourceManager.AddEmployee("Aygun", "SMM", 1200, "Marketing");
humanResourceManager.AddEmployee("Kamran", "Content", 1000, "Marketing");

// Departamentləri göstər
humanResourceManager.GetDepartments();