namespace HRManagementApplication.Interfaces
{
    public interface IHumanResourceManager
    {
        List<Department> Departments { get; set; }

        void AddDepartment(string name, int workerLimit, decimal salaryLimit);

        void GetDepartments();

        void EditDepartments(string name, string newName);

        void AddEmployee(string fullName, string position, decimal salary, string departmentName);
        void RemoveEmployee(string no, string departmentName);

        void EditEmployee(string no, decimal newSalary, string newPosition);

        void Search(string searchText);

        void GetEmployees();

        void GetEmployeesByDepartment(string departmentName);

        void CalculateAverageSalary(string departmentName);


    }
}
