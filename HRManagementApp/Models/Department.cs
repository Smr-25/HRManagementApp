using Newtonsoft.Json;
namespace HRManagementApp.Models
{
    public class Department
    {
        public static int id = 1000;
        public List<Employee> Employees { get; set; } = new();
        public Department(string name, int workerLimit, int salaryLimit)
        {
            Name = name;
            WorkerLimit = workerLimit;
            SalaryLimit = salaryLimit;
        }
        

        private string _name;
        public string  Name
        {
            get
            {
                return _name;
            }
            set
            {
                if(value.Length < 2)
                {
                    throw new Exception("Department name must be greater than 2 letter ");
                }

                _name = value;  
            }
        
        }

        private int _workerLimit;
        public int WorkerLimit {

            get
            {
                return _workerLimit;
            }
            set
            {
                if (value < 1)
                {
                    throw new Exception("Department worker limit must be greater than 1");
                }

                _workerLimit = value;
            }

        }

        private int _salaryLimit;
        public int SalaryLimit {

            get
            {
                return _salaryLimit;
            }

            set
            {
                if(value < 250)
                {
                    throw new Exception("Department salary limit must be greater than 250");
                }

                _salaryLimit = value;
            }
        }
        public double CalcSalaryAverage()
        {
            if(Employees == null)
                 return 0;
            return Employees.Average(e=>e.Salary);
        }

        public override string ToString()
        {
            return $"{Name} {WorkerLimit} {SalaryLimit} ";
        }

    }
}
