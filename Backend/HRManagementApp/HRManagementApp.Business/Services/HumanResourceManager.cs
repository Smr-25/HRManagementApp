using System;
using System.Collections.Generic;
using System.Linq;
using HRManagementApp.Core.Entities;
using HRManagementApp.Core.Interfaces;

namespace HRManagementApp.Business.Services;

public class HumanResourceManager : IHumanResourceManager
{
    public List<Department> Departments { get; } = new List<Department>();

    private static int _employeeCount = 1000;

    public void AddDepartment(string name, int workerLimit, double salaryLimit)
    {
        if (Departments.Any(d => d.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
            throw new Exception("Department with this name already exists!");

        var department = new Department
        {
            Name = name,
            WorkerLimit = workerLimit,
            SalaryLimit = salaryLimit
        };

        Departments.Add(department);
    }

    public List<Department> GetDepartments()
    {
        return Departments;
    }

    public void EditDepartments(string oldName, string newName)
    {
        var department = Departments.FirstOrDefault(d => d.Name.Equals(oldName, StringComparison.OrdinalIgnoreCase));
        if (department == null)
            throw new Exception("Department not found!");
            
        if (Departments.Any(d => d.Name.Equals(newName, StringComparison.OrdinalIgnoreCase)))
            throw new Exception("Department with this new name already exists!");

        department.Name = newName;
        
        foreach (var emp in department.Employees)
        {
            emp.DepartmentName = newName;
        }
    }

    public void AddEmployee(string fullName, string position, double salary, string departmentName)
    {
        var department = Departments.FirstOrDefault(d => d.Name.Equals(departmentName, StringComparison.OrdinalIgnoreCase));
        if (department == null)
            throw new Exception("Specified department not found!");

        if (department.Employees.Count >= department.WorkerLimit)
            throw new Exception("Worker limit in the department has been reached!");

        if (department.Employees.Sum(e => e.Salary) + salary > department.SalaryLimit)
            throw new Exception("Department salary limit has been exceeded!");

        _employeeCount++;
        
        string prefix = department.Name.Length >= 2 
            ? department.Name.Substring(0, 2).ToUpper() 
            : department.Name.ToUpper();
            
        string employeeNo = $"{prefix}{_employeeCount}";

        var employee = new Employee
        {
            No = employeeNo,
            FullName = fullName,
            Position = position,
            Salary = salary,
            DepartmentName = department.Name
        };

        department.Employees.Add(employee);
    }

    public void RemoveEmployee(string no, string departmentName)
    {
        var department = Departments.FirstOrDefault(d => d.Name.Equals(departmentName, StringComparison.OrdinalIgnoreCase));
        if (department == null)
            throw new Exception("Department not found!");

        var employee = department.Employees.FirstOrDefault(e => e.No.Equals(no, StringComparison.OrdinalIgnoreCase));
        if (employee == null)
            throw new Exception("Employee with this number not found!");

        department.Employees.Remove(employee);
    }

    public void EditEmployee(string no, string position, double salary)
    {
        bool isFound = false;
        foreach (var department in Departments)
        {
            var employee = department.Employees.FirstOrDefault(e => e.No.Equals(no, StringComparison.OrdinalIgnoreCase));
            if (employee != null)
            {
                if (salary != employee.Salary)
                {
                    double newTotalSalary = department.Employees.Sum(e => e.Salary) - employee.Salary + salary;
                    if (newTotalSalary > department.SalaryLimit)
                        throw new Exception("Salary increase exceeds the department's salary limit!");
                }
                
                employee.Position = position;
                employee.Salary = salary;
                isFound = true;
                break;
            }
        }

        if (!isFound)
            throw new Exception("Employee with the specified number not found!");
    }

    public List<Employee> Search(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
            return new List<Employee>();

        query = query.ToLower();
        var allEmployees = Departments.SelectMany(d => d.Employees).ToList();
        
        return allEmployees.Where(e => 
            e.FullName.ToLower().Contains(query) || 
            e.No.ToLower().Contains(query) || 
            e.Position.ToLower().Contains(query) || 
            e.DepartmentName.ToLower().Contains(query)
        ).ToList();
    }
}
