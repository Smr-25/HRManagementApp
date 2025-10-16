
using HRManagementApp.Interfaces;
using HRManagementApp.Models;

namespace HRManagementApp.Services
{
    public class HumanResourceManager : IHumanResourceManager
    {
        public List<Department> Departments { get; set; } = new();
        // public List<Employee> Employees { get; set; } = new();

        public void AddDepartment(string name, int workerLimit, int salaryLimit)
        {
            if (Departments.Any(d => d.Name == name))
            {
                throw new Exception("Department already exists");
            }

            Departments.Add(new(name, workerLimit, salaryLimit));
        }

        public void EditDepartaments(string name, string newName)
        {
            if (Departments.Any(d => d.Name == name))
            {
                if (Departments.Any(d => d.Name == newName))
                {
                    throw new Exception("Department already exists");
                }

                var depatment = Departments.Find(d => d.Name == name);
                depatment.Name = newName;
            }
            else
            {
                throw new Exception("Department does not exist");
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
                if (department.Employees.Count >= department.WorkerLimit)
                    throw new Exception("Employee limit exceeded");


                int totalSalary = department.Employees.Sum(e => e.Salary);
                if (totalSalary >= department.SalaryLimit)
                    throw new Exception("Salary limit exceeded");

                department.Employees.Add(new Employee(fullName, position, salary, departmentName));

            }
            else
            {
                throw new Exception("Department not found");
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
                    throw new Exception("Employee not found");
                }
            }
            else
            {
                throw new Exception("Department not found");
            }
        }

        public void EditEmployee(string no, int newSalary, string newPosition)
        {
            if (Departments.Any(d => d.Employees.Any(e => e.No == no)))
            {
                var department = Departments.Find(d => d.Employees.Any(e => e.No == no));
                var employee = department.Employees.Find(e => e.No == no);
                employee.Salary = newSalary;
                employee.Position = newPosition;
            }
            else
            {
                throw new Exception("Employee not found");
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
    }
}   
    