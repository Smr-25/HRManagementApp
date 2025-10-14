namespace HRManagementApp.Models
{
    public class Department
    {
        public Department(string name, int workerLimit, int salaryLimit)
        {
            Name = name;
            WorkerLimit = workerLimit;
            SalaryLimit = salaryLimit;
        }

        public string  Name { get; set; }

        public int WorkerLimit { get; set; }

        public int SalaryLimit { get; set; }

        public List<Employee> Employees { get; set; } = [];

        public double CalcSalaryAverage()
        {
            return 0;
        }
    }
}
