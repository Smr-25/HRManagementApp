using HRManagementApp.Interfaces;
using HRManagementApp.Services;

namespace HRManagementApp.Executes;

public class ExecuteDepartment : IExecuteDepartment
{
    private static IHumanResourceManager _hrManager = new HumanResourceManager();
    
    public void AddDepartment()
    {
        Console.WriteLine("\n--- ADD NEW DEPARTMENT ---");
        Name:
        Console.Write("Department Name: ");
         string name = Console.ReadLine();
            
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Invalid department name!");
            goto Name;
        }
            
        WorkerLimit: 
        Console.Write("Employee Limit: ");
        
        string workerLimitStr = Console.ReadLine();
        if (!int.TryParse(workerLimitStr, out int workerLimit))
        {
            Console.WriteLine("Invalid employee limit!");
            goto WorkerLimit;
        }
            
        SalaryLimit : 
        Console.Write("Salary Limit: ");
        
       string salaryLimitStr = Console.ReadLine();
        if (!int.TryParse(salaryLimitStr, out int salaryLimit))
        {
            Console.WriteLine("Invalid salary limit!");
            goto SalaryLimit;
        }

        _hrManager.AddDepartment(name, workerLimit, salaryLimit);
        Console.WriteLine("Department added successfully!");
    }
    
    public void EditDepartment()
    {
        Console.WriteLine("\n--- EDIT DEPARTMENT ---");
        
        DepartmentName: 
        Console.Write("Department name to edit: ");
        string oldName = Console.ReadLine();
        
    
        Console.Write("New department name: ");
        string newName = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(oldName) || string.IsNullOrWhiteSpace(newName))
        {
            Console.WriteLine("Invalid department names!");
            goto DepartmentName;
        }

        _hrManager.EditDepartments(oldName, newName);
        Console.WriteLine("Department updated successfully!");
    }
    
    public void ListDepartments()
    {
        Console.WriteLine("\n--- DEPARTMENTS LIST ---");
        _hrManager.GetDepartments();
    }
    
}