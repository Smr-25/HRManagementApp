using HRManagementApp.Models;

namespace HRManagementApp.Interfaces
{
    internal interface IHumanResourceManager
    {
        List<Department> Departments { get; set; }

        void AddDepartment(string name,int workerLimit, int salaryLimit);

        void GetDepartments();

        void EditDepartaments(string name, string newName);

        void AddEmployee(string fullName, string position, int salary,string departmentName);
        void RemoveEmployee(string no, string departmentName);

        void EditEmployee(string no, int newSalary, string newPosition);

        void Search(string searchText);

        
    }
}
