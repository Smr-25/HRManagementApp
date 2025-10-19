namespace HRManagementApp.Executes;

public class ExecuteDepartment : IExecuteDepartment
{
    
    
    private readonly IHumanResourceManager _hrManager;

    public ExecuteDepartment(IHumanResourceManager hrManager)
    {
        _hrManager = hrManager;
    }

    public void AddDepartment()
    {
        Console.WriteLine("\n--- ADD NEW DEPARTMENT ---");

        Name:
        Console.WriteLine("Department Name: ");
        string? name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Invalid department name!");
            goto Name;
        }

        WorkerLimit:
        Console.WriteLine("Employee Limit: ");
        string? workerLimitStr = Console.ReadLine();
        if (!int.TryParse(workerLimitStr, out int workerLimit))
        {
            Console.WriteLine("Invalid employee limit!");
            goto WorkerLimit;
        }

        SalaryLimit:
        Console.WriteLine("Salary Limit: ");
        string? salaryLimitStr = Console.ReadLine();
        if (!decimal.TryParse(salaryLimitStr, out decimal salaryLimit))
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
        Console.WriteLine("Department Name: ");
        string? oldName = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(oldName))
        {
            Console.WriteLine("Invalid department name!");
            goto DepartmentName;
        }

        NewName:
        Console.WriteLine("New Department Name: ");
        string? newName = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(newName))
        {
            Console.WriteLine("Invalid new department name!");
            goto NewName;
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
