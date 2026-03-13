namespace HRManagementApplication.Models
{
    public class Employee
    {

        public Employee(int id, string fullName, string position, decimal salary, string departmentName)
        {

            No = departmentName.ToUpper().Substring(0, 2) + $"{id}";
            FullName = fullName;
            Position = position;
            Salary = salary;
            DepartmentName = departmentName;
        }

        public string No { get; set; }

        public string FullName { get; set; }

        private string _pos = string.Empty;
        public string Position
        {
            get
            {
                return _pos;
            }

            set
            {
                if (value.Length < 2)
                {
                    throw new InvalidEmployeePositionException("Position length must be at least 2 characters.");
                }
                _pos = value;
            }
        }

        private decimal _salary;
        public decimal Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                if (value < 250M)
                {
                    throw new InvalidSalaryException("Salary must be at least 250.");
                }

                _salary = value;
            }

        }

        public string DepartmentName { get; set; }

        public override string ToString()
        {
            return $"{No} {FullName} {Position} {Salary} {DepartmentName}";
        }
    }
}
