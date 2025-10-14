namespace HRManagementApp.Models
{
    public class Employee
    {
        public Employee(string fullName, string position, int salary, string departmentName)
        {
            FullName = fullName;
            Position = position;
            Salary = salary;
            DepartmentName = departmentName;
        }

        public int No { get; set; }

        public string FullName { get; set; }

        public string Position { get; set; }

        public int Salary { get; set; }

        public string DepartmentName { get; set; }
    }
}
