namespace HRManagementApp
{
    public class Program
    {
        static void Main()
        {
            IHumanResourceManager hrManager = new HumanResourceManager();
            IExecuteDepartment executeDepartment = new ExecuteDepartment(hrManager);
            IExecuteEmployee executeEmployee = new ExecuteEmployee(hrManager);
            

            while (true)
            {
                Console.WriteLine("--- HR MANAGEMENT MENU ---");
                Console.WriteLine("1. Add Department");
                Console.WriteLine("2. Edit Department");
                Console.WriteLine("3. List Departments");
                Console.WriteLine("4. Add Employee");
                Console.WriteLine("5. Remove Employee");
                Console.WriteLine("6. List Employees");
                Console.WriteLine("7. List Employees by Department");
                Console.WriteLine("8. Edit Employee");
                Console.WriteLine("9. Search Employees");
                Console.WriteLine("10. Calculate Average Salary by Department");
                Console.WriteLine("11. Exit");
                
                Input:
                Console.Write("Select option (1-11): ");
                
                var inputStr = Console.ReadLine();
                if (!int.TryParse(inputStr, out var input))
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 10.");
                    goto Input;
                }
                Console.WriteLine();

                try
                {
                    switch (input)
                    {
                        case (int)MenuOptions.AddDepartment:
                            executeDepartment.AddDepartment();
                            break;
                        case (int)MenuOptions.EditDepartment:
                            executeDepartment.EditDepartment();
                            break;
                        case (int)MenuOptions.ListDepartments:
                            executeDepartment.ListDepartments();
                            break;
                        case (int)MenuOptions.AddEmployee:
                            executeEmployee.AddEmployee();
                            break;
                        case (int)MenuOptions.RemoveEmployee:
                           executeEmployee.RemoveEmployee();
                            break;
                        case (int)MenuOptions.ListEmployees:
                            executeEmployee.ListEmployees();
                            break;
                        case (int)MenuOptions.ListEmployeesByDepartment:
                            executeEmployee.ListEmployeesByDepartment();
                            break;
                        case (int)MenuOptions.EditEmployee:
                           executeEmployee.EditEmployee();
                            break;
                        case (int)MenuOptions.SearchEmployees:
                            executeEmployee.Search();
                            break;
                        case (int)MenuOptions.CalculateAverageSalary:
                            executeEmployee.CalculateAverageSalary();
                            break;
                        case (int)MenuOptions.Exit:
                            Console.WriteLine("Exiting application...");
                            return;
                        default:
                            Console.WriteLine("Invalid option.");
                            goto Input;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    goto Input;
                }
                
            }
        }
    }
}