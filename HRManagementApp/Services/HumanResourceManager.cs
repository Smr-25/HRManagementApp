using HRManagementApp.Files;
using HRManagementApp.Interfaces;
using HRManagementApp.Models;
using HRManagementApp.Exceptions;

namespace HRManagementApp.Services
{
    public class HumanResourceManager : IHumanResourceManager
    {
        public List<Department> Departments { get; set; } = new();

        public HumanResourceManager()
        {
            Departments = FileGuider.ReadJsonFile();
        }

        public void AddDepartment(string name, int workerLimit, int salaryLimit)
        {
            if (Departments.Any(d => d.Name.ToLower() == name.ToLower()))
            {
                throw new DepartmentAlreadyExistsException("Department " + name + " already exists.");
            }

            Departments.Add(new(name, workerLimit, salaryLimit));
            FileGuider.WriteJsonFile(Departments);
        }

        public void EditDepartments(string name, string newName)
        {
            if (Departments.Any(d => d.Name == name))
            {
                if (Departments.Any(d => d.Name == newName))
                {
                    throw new DepartmentAlreadyExistsException("Department " + newName + " already exists.");
                }

                var depatment = Departments.Find(d => d.Name == name);
                depatment.Name = newName;
                FileGuider.WriteJsonFile(Departments);
            }
            else
            {
                throw new DepartmentNotFoundException("Department " + name + " not found.");
            }

        }

        public void GetDepartments()
        {
            foreach (var item in Departments)
            {
                Console.WriteLine(item);
            }
        }

        public void AddEmployee(string fullName, string position, int salary, string departmentName)
        {
            if (Departments.Any(d => d.Name == departmentName))
            {
                var department = Departments.Find(d => d.Name == departmentName);

                if (department.Employees.Any(e => e.FullName.ToLower() == fullName.ToLower()))
                {
                    throw new EmployeeAlreadyExistsException("Employee " + fullName + " already exists in department " +
                                                             departmentName);
                }

                if (department.Employees.Count >= department.WorkerLimit)
                    throw new EmployeeLimitExceededException("Worker limit exceeded for department " + departmentName);

                int totalSalary = department.Employees.Sum(e => e.Salary);
                if (totalSalary >= department.SalaryLimit)
                    throw new SalaryLimitExceededException("Salary limit exceeded for department " + departmentName);

                department.Employees.Add(new Employee(fullName, position, salary, departmentName));
                FileGuider.WriteJsonFile(Departments);
            }
            else
            {
                throw new DepartmentNotFoundException("Department " + departmentName + " not found.");
            }
        }

        public void RemoveEmployee(string no, string departmentName)
        {
            if (Departments.Any(d => d.Name == departmentName))
            {
                var department = Departments.Find(d => d.Name == departmentName);
                if (department.Employees.Any(e => e.No == no))
                {
                    var employee = department.Employees.Find(e => e.No == no);
                    department.Employees.Remove(employee);
                }
                else
                {
                    throw new EmployeeNotFoundException("Employee with no " + no + " not found in department " +
                                                        departmentName);
                }

                FileGuider.WriteJsonFile(Departments);
            }
            else
            {
                throw new DepartmentNotFoundException("Department " + departmentName + " not found.");
            }
        }

        public void EditEmployee(string no, int newSalary, string newPosition)
        {
            var employees = Departments.SelectMany(e => e.Employees);
            if (employees.Any(e => e.No == no))
            {
                var employee = employees.FirstOrDefault(e => e.No == no);
                employee.Salary = newSalary;
                employee.Position = newPosition;
                FileGuider.WriteJsonFile(Departments);
            }
            else
            {
                throw new EmployeeNotFoundException("Employee with no " + no + " not found.");
            }
        }

        public void Search(string searchText)
        {
            foreach (var department in Departments)
            {
                foreach (var employee in department.Employees)
                {
                    if (employee.FullName.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                        employee.Position.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                        employee.No.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                        employee.DepartmentName.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine(employee);
                    }
                }
            }
        }

        public void GetEmployeesByDepartment(string departmentName)
        {
            if (Departments.Any(d => d.Name == departmentName))
            {
                var department = Departments.Find(d => d.Name == departmentName);
                foreach (var employee in department.Employees)
                {
                    Console.WriteLine(employee);
                }
            }
            else
            {
                throw new DepartmentNotFoundException("Department " + departmentName + " not found.");
            }
        }

        public void GetEmployees()
        {
            Console.WriteLine("\n--- EMPLOYEE LIST ---");
            foreach (var department in Departments)
            {
                Console.WriteLine($"\nDepartment: {department.Name}");
                if (department.Employees.Count == 0)
                {
                    Console.WriteLine("No employees in this department.");
                }
                else
                {
                    foreach (var employee in department.Employees)
                    {
                        Console.WriteLine(employee);
                    }
                }
            }
        }
    }
}
