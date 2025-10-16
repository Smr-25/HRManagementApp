
using HRManagementApp.Files;
using HRManagementApp.Interfaces;
using HRManagementApp.Models;

namespace HRManagementApp.Services
{
    public class HumanResourceManager : IHumanResourceManager
    {
        //FileGuider fileGuider = new FileGuider();

        public List<Department> Departments { get; set; } = new();
        // public List<Employee> Employees { get; set; } = new();

        public HumanResourceManager() { 
      
           Departments = FileGuider.ReadJsonFile();
    
        }   
        public void AddDepartment(string name, int workerLimit, int salaryLimit)
        {
            //fileGuider.CreateFile(ref fileGuider.path);
            if (Departments.Any(d => d.Name.ToLower() == name.ToLower()))
            {
                throw new Exception("Department already exists");
            }
            Departments.Add(new(name, workerLimit, salaryLimit));
            FileGuider.WriteJsonFile(Departments);
            Console.WriteLine("Added");
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
                FileGuider.WriteJsonFile(Departments);
            }
            else
            {
                throw new Exception("Department does not exist");
            }
            Console.WriteLine("Updated");
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
                
                if(department.Employees.Any(e=>e.FullName.ToLower() == fullName.ToLower()))
                {
                    throw new Exception("Employee already exits");
                }
                if (department.Employees.Count >= department.WorkerLimit)
                    throw new Exception("Employee limit exceeded");


                int totalSalary = department.Employees.Sum(e => e.Salary);
                if (totalSalary >= department.SalaryLimit)
                    throw new Exception("Salary limit exceeded");
                
                department.Employees.Add(new Employee(fullName, position, salary, departmentName));
                FileGuider.WriteJsonFile(Departments);
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

                FileGuider.WriteJsonFile(Departments);
            }
            else
            {
                throw new Exception("Department not found");
            }
        }

        public void EditEmployee(string no, int newSalary, string newPosition)
        {
            var employees = Departments.SelectMany(e => e.Employees);
            if (employees.Any(e=>e.No == no))
            {
                var employee = employees.FirstOrDefault(e => e.No == no);
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
    