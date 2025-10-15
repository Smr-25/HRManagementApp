using HRManagementApp.Models;

namespace HRManagementApp.Interfaces
{
    internal interface IHumanResourceManager
    {
        public List<Department> Departments { get; set; }

        public void AddDepartment(string name,int workerLimit, int salaryLimit);

        public void GetDepartments();

        public void EditDepartaments(string name, string newName);

        void AddEmployee(string fullName, string position, int salary,string departmentName);
        public void RemoveEmployee(string no, string departmentName);

        public void Search(string searchText);

        
    }
}
