using System;
using HRManagementApp.Executes;
using HRManagementApp.Interfaces;

namespace HRManagementApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            IExecuteDepartment executeDepartment = new ExecuteDepartment();
            IExecuteEmployee executeEmployee = new ExecuteEmployee();
            

            while (true)
            {
                Console.Clear();
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
                Console.WriteLine("10. Exit");
                
                Input:
                Console.Write("Select option (1-10): ");
                
                var input = Console.ReadLine();
                Console.WriteLine();

                try
                {
                    switch (input)
                    {
                        case "1":
                            executeDepartment.AddDepartment();
                            break;
                        case "2":
                            executeDepartment.EditDepartment();
                            break;
                        case "3":
                            executeDepartment.ListDepartments();
                            break;
                        case "4":
                            executeEmployee.AddEmployee();
                            break;
                        case "5":
                           executeEmployee.RemoveEmployee();
                            break;
                        case "6":
                            executeEmployee.ListEmployees();
                            break;
                        case "7":
                            executeEmployee.ListEmployeesByDepartment();
                            break;
                        case "8":
                           executeEmployee.EditEmployee();
                            break;
                        case "9":
                            executeEmployee.Search();
                            break;
                        case "10":
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