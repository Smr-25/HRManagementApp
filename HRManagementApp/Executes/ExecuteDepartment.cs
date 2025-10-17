using HRManagementApp.Services;

namespace HRManagementApp.Executes;

public class ExecuteDepartment
{
    private static HumanResourceManager _hrManager = new HumanResourceManager();
    
    public void AddDepartment()
    {
        Console.WriteLine("\n--- ADD NEW DEPARTMENT ---");
        Console.Write("Department Name: ");
        string name = Console.ReadLine();
            
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Invalid department name!");
            return;
        }
            
        Console.Write("Employee Limit: ");
        if (!int.TryParse(Console.ReadLine(), out int workerLimit))
        {
            Console.WriteLine("Invalid employee limit!");
            return;
        }
            
        Console.Write("Salary Limit: ");
        if (!int.TryParse(Console.ReadLine(), out int salaryLimit))
        {
            Console.WriteLine("Invalid salary limit!");
            return;
        }

        _hrManager.AddDepartment(name, workerLimit, salaryLimit);
        Console.WriteLine("Department added successfully!");
    }
    
    public void EditDepartment()
    {
        Console.WriteLine("\n--- EDIT DEPARTMENT ---");
        Console.Write("Department name to edit: ");
        string? oldName = Console.ReadLine();
            
        Console.Write("New department name: ");
        string? newName = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(oldName) || string.IsNullOrWhiteSpace(newName))
        {
            Console.WriteLine("Invalid department names!");
            return;
        }

        _hrManager.EditDepartaments(oldName, newName);
        Console.WriteLine("Department updated successfully!");
    }
}