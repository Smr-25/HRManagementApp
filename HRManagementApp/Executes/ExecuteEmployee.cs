namespace HRManagementApp.Executes;

public class ExecuteEmployee : IExecuteEmployee
{
    private readonly IHumanResourceManager _hrManager = new HumanResourceManager();

    public void AddEmployee()
    {
        Console.WriteLine("\n--- ADD NEW EMPLOYEE ---");

        DepartmentName:
        Console.Write("Department Name: ");
        string? departmentName = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(departmentName))
        {
            Console.WriteLine("Invalid department name!");
            goto DepartmentName;
        }

        FullName:
        Console.Write("Full Name: ");
        string? fullName = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(fullName))
        {
            Console.WriteLine("Invalid employee name!");
            goto FullName;
        }

        Position:
        Console.Write("Position: ");
        string? position = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(position))
        {
            Console.WriteLine("Invalid position!");
            goto Position;
        }

        Salary:
        Console.Write("Salary: ");
        string? salaryStr = Console.ReadLine();
        if (!int.TryParse(salaryStr, out int salary) || salary < 0)
        {
            Console.WriteLine("Invalid salary!");
            goto Salary;
        }

        _hrManager.AddEmployee(fullName, position, salary, departmentName);
        Console.WriteLine("Employee added successfully!");
       
        
    }

    public void EditEmployee()
    {
        Console.WriteLine("\n--- EDIT EMPLOYEE ---");

        EmployeeNo:
        Console.Write("Employee No: ");
        string? no = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(no))
        {
            Console.WriteLine("Invalid employee no!");
            goto EmployeeNo;
        }

        NewPosition:
        Console.Write("New Position: ");
        string? newPosition = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(newPosition))
        {
            Console.WriteLine("Invalid position!");
            goto NewPosition;
        }

        NewSalary:
        Console.Write("New Salary: ");
        string? newSalaryStr = Console.ReadLine();
        if (!int.TryParse(newSalaryStr, out int newSalary) || newSalary < 0)
        {
            Console.WriteLine("Invalid salary!");
            goto NewSalary;
        }

      
        _hrManager.EditEmployee(no, newSalary, newPosition);
        Console.WriteLine("Employee edited successfully!");
       
    }

    public void RemoveEmployee()
    {
        Console.WriteLine("\n--- DELETE EMPLOYEE ---");

        DepartmentName:
        Console.Write("Department Name: ");
        string? departmentName = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(departmentName))
        {
            Console.WriteLine("Invalid department name!");
            goto DepartmentName;
        }

        EmployeeNo:
        Console.Write("Employee No: ");
        string? no = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(no))
        {
            Console.WriteLine("Invalid employee no!");
            goto EmployeeNo;
        }

        _hrManager.RemoveEmployee(no, departmentName);
        Console.WriteLine("Employee deleted successfully!");
        
        
    }

    public void ListEmployees()
    {
        Console.WriteLine("\n--- EMPLOYEE LIST ---");
        _hrManager.GetEmployees();
    }

    public void ListEmployeesByDepartment()
    {
        DepartmentName:
        Console.Write("Department Name: ");
        string? departmentName = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(departmentName))
        {
            Console.WriteLine("Invalid department name!");
            goto DepartmentName;
        }

        Console.WriteLine($"\n--- {departmentName} EMPLOYEE LIST ---");
        _hrManager.GetEmployeesByDepartment(departmentName);
        
    }

    public void CalculateAverageSalary()
    {
      DepartmentName:
        Console.Write("Department Name: ");
        string? departmentName = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(departmentName))
        {
            Console.WriteLine("Invalid department name!");
            goto DepartmentName;
        }
        _hrManager.CalculateAverageSalary(departmentName);
    }

    public void Search()
    {
        Console.WriteLine("\n--- SEARCH EMPLOYEES ---");

        SearchText:
        Console.Write("Search Text: ");

        string? searchText = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(searchText))
        {
            Console.WriteLine("Invalid search text!");
            goto SearchText;
        }

       
        _hrManager.Search(searchText);
       
    }
}