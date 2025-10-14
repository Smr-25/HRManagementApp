using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRManagementApp.Interfaces;
using HRManagementApp.Models;

namespace HRManagementApp.Services
{
    public class HumanResourceManager : IHumanResourceManager
    {
        public List<Department> Departments { get; set; } = [];

        public List<Employee> Employees { get; set; }

        public void AddDepartment(string name,int workerLimit, int salaryLimit)
        {
            Department department = new(name,workerLimit,salaryLimit);
            Departments.Add(department);
        }

        public void EditDepartaments(string name,string newName)
        {
            if (Departments.Any(d=>d.Name == name))
            {
                var depatment = Departments.Find(d => d.Name == name);
                depatment.Name = newName;
            }
        }

        public void GetDepartments()
        {
            foreach (var item in Departments)
            {
                Console.WriteLine(item.Name+" "+item.WorkerLimit+" "+item.SalaryLimit);
            }
        }

        public void AddEmployee(string fullName, string position, int salary,string departmentName)
        {
            Employee employee = new(fullName,position,salary,departmentName);
            Employees.Add(employee);
        }
        public void RemoveEmployee(int no,string departmentName)
        {
            var employee = Employees.Find(e => e.No == no);
            Employees.Remove(employee);
        }

        public void Search(string searchText)
        {
            if (Employees.Any())
            {
                return;
            }
        }
    }
}
