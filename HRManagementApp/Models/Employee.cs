using HRManagementApp.Files;
using HRManagementApp.Exceptions;

namespace HRManagementApp.Models
{
    public class Employee
    {
        
        private static int _no = 1000;
        
        public Employee(string fullName, string position, int salary, string departmentName)
        {
           
            No = departmentName.ToUpper().Substring(0, 2) + $"{_no++}";
            FullName = fullName;
            Position = position;
            Salary = salary;
            DepartmentName = departmentName;
        }
   
        public string No { get; set; }

        public string FullName { get; set; }

        private string pos;
        public string Position
        {
            get
            {
                return pos;
            }

            set
            {
                if (value.Length < 2)
                {
                    throw new InvalidEmployeePositionException("Position length must be at least 2 characters.");
                }
                pos = value;
            }
        }

        private int _salary;
        public int Salary {
            get
            {
                return _salary;
            }
            set
            {
                if (value < 250)
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
