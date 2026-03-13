namespace HRManagementApplication.Models;

public class Department
{

    private int _lastEmployeeId = 1000;
    private readonly object _idLock = new();

    public List<Employee> Employees { get; set; } = new();
    public Department(string name, int workerLimit, decimal salaryLimit)
    {
        Name = name;
        WorkerLimit = workerLimit;
        SalaryLimit = salaryLimit;
    }


    private string _name = string.Empty;
    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            if (value.Length < 2)
            {
                throw new InvalidDepartmentNameException("Department name must be at least 2 characters long");
            }

            _name = value;
        }

    }

    private int _workerLimit;
    public int WorkerLimit
    {

        get
        {
            return _workerLimit;
        }
        set
        {
            if (value < 1)
            {
                throw new EmployeeLimitExceededException("Department worker limit must be greater than 1");
            }

            _workerLimit = value;
        }

    }

    private decimal _salaryLimit;
    public decimal SalaryLimit
    {

        get
        {
            return _salaryLimit;
        }

        set
        {
            if (value < 250M)
            {
                throw new SalaryLimitExceededException("Department salary limit must be greater than 250");
            }

            _salaryLimit = value;
        }
    }



    public decimal CalcSalaryAverage()
    {
        if (Employees.Count == 0)
            return 0M;
        return Employees.Average(e => e.Salary);
    }

    public override string ToString()
    {
        return $"Name: {Name} Worker Limit: {WorkerLimit} Salary Limit {SalaryLimit} ";
    }

    public int GetNextEmployeeId()
    {
        lock (_idLock)
        {
            _lastEmployeeId++;
            return _lastEmployeeId;
        }
    }

    public void InitializeLastEmployeeId()
    {
        if (Employees.Count > 0)
        {
            var maxId = 1000;
            foreach (var employee in Employees)
            {
                if (employee.No.Length > 2)
                {
                    var idPart = employee.No.Substring(2);
                    if (int.TryParse(idPart, out int currentId))
                    {
                        if (currentId > maxId)
                            maxId = currentId;
                    }
                }
            }
            lock (_idLock)
            {
                _lastEmployeeId = maxId;
            }
        }
    }
}
