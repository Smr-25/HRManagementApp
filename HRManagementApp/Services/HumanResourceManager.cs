namespace HRManagementApp.Services;

    public class HumanResourceManager : IHumanResourceManager
    {
        public List<Department> Departments { get; set; }

        public HumanResourceManager()
        {
            Departments = FileGuider.ReadJsonFile();
            
            foreach (var department in Departments)
            {
                department.InitializeLastEmployeeId();
            }
        }

        public void AddDepartment(string name, int workerLimit, int salaryLimit)
        {
            name = name.Trim();
            if (Departments.Any(d => d.Name.ToLower() == name.ToLower()))
            {
                throw new DepartmentAlreadyExistsException("Department " + name + " already exists.");
            }
            
            var newDepartment = new Department(name, workerLimit, salaryLimit);
            newDepartment.InitializeLastEmployeeId();
            Departments.Add(newDepartment);
            FileGuider.WriteJsonFile(Departments);
        }

        public void EditDepartments(string name, string newName)
        {
            name = name.Trim();
            newName = newName.Trim();
            
            if (Departments.Any(d => d.Name.ToLower() == name.ToLower()))
            {
                if (Departments.Any(d => d.Name.ToLower() == newName.ToLower()))
                {
                    throw new DepartmentAlreadyExistsException("Department " + newName + " already exists.");
                }

                var department = Departments.First(d => d.Name.ToLower() == name.ToLower());
                department.Name = newName;
                foreach (var employee in department.Employees)
                {
                   employee.No = employee.No.Replace(employee.No.Substring(0, 2), newName.ToUpper().Substring(0, 2));
                   employee.DepartmentName = newName;
                }
                FileGuider.WriteJsonFile(Departments);
            }
            else
            {
                throw new DepartmentNotFoundException("Department " + name + " not found.");
            }

        }

        public void GetDepartments()
        {
            foreach (var item in Departments)
            {
                Console.WriteLine(item);
            }
        }

        public void AddEmployee(string fullName, string position, int salary, string departmentName)
        {
            fullName = fullName.Trim();
            position = position.Trim();
            departmentName = departmentName.Trim();
            
            if (Departments.Any(d => d.Name.ToLower() == departmentName.ToLower()))
            {
                var department = Departments.First(d => d.Name.ToLower() == departmentName.ToLower());

                if (department.Employees.Any(e => e.FullName.ToLower() == fullName.ToLower()))
                    throw new EmployeeAlreadyExistsException("Employee " + fullName + " already exists in department " +
                                                             departmentName);


                if (department.Employees.Count >= department.WorkerLimit)
                    throw new EmployeeLimitExceededException("Worker limit exceeded for department " + departmentName);

                int totalSalary = department.Employees.Sum(e => e.Salary);
                if (totalSalary >= department.SalaryLimit)
                    throw new SalaryLimitExceededException("Salary limit exceeded for department " + departmentName);

                int newId = department.GetNextEmployeeId();
                department.Employees.Add(new Employee(newId,fullName, position, salary, department.Name));
                FileGuider.WriteJsonFile(Departments);
            }
            else
            {
                throw new DepartmentNotFoundException("Department " + departmentName + " not found.");
            }
        }

        public void RemoveEmployee(string no, string departmentName)
        {
            no = no.Trim();
            departmentName = departmentName.Trim();
            
            if (Departments.Any(d => d.Name.ToLower() == departmentName.ToLower()))
            {
                var department = Departments.First(d => d.Name.ToLower() == departmentName.ToLower());
                if (department.Employees.Any(e => e.No == no))
                {
                    var employee = department.Employees.First(e => e.No == no);
                    department.Employees.Remove(employee);
                }
                else
                {
                    throw new EmployeeNotFoundException("Employee with no " + no + " not found in department " +
                                                        departmentName);
                }

                FileGuider.WriteJsonFile(Departments);
            }
            else
            {
                throw new DepartmentNotFoundException("Department " + departmentName + " not found.");
            }
        }

        public void EditEmployee(string no, int newSalary, string newPosition)
        {
            no = no.Trim();
            newPosition = newPosition.Trim();
            
            var employee = Departments.SelectMany(d => d.Employees).FirstOrDefault(e => e.No == no);
            if (employee != null)
            {
                if(Departments.Any(d => d.Name == employee.DepartmentName))
                {
                    var department = Departments.First(d => d.Name == employee.DepartmentName);
                    int totalSalaryExcludingCurrent = department.Employees.Where(e => e.No != no).Sum(e => e.Salary);
                    if (totalSalaryExcludingCurrent + newSalary > department.SalaryLimit)
                    {
                        throw new SalaryLimitExceededException("Salary limit exceeded for department " + department.Name);
                    }
                }
                employee.Salary = newSalary;
                employee.Position = newPosition;
                FileGuider.WriteJsonFile(Departments);
            }
            else
            {
                throw new EmployeeNotFoundException("Employee with no " + no + " not found.");
            }
        }

        public void Search(string searchText)
        {
            searchText = searchText.Trim();
            
            foreach (var department in Departments)
            {
                foreach (var employee in department.Employees)
                {
                    if (employee.FullName.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                        employee.Position.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                        employee.No.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                        employee.DepartmentName.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine(employee);
                    }
                }
            }
        }

        public void GetEmployeesByDepartment(string departmentName)
        {
            departmentName = departmentName.Trim();
            
            if (Departments.Any(d => d.Name.ToLower() == departmentName.ToLower()))
            {
                var department = Departments.FirstOrDefault(d => d.Name.ToLower() == departmentName.ToLower());
                if (department != null)
                {
                    foreach (var employee in department.Employees)
                    {
                        Console.WriteLine(employee);
                    }
                }
                else
                {
                    Console.WriteLine("No employees in this department.");
                }
            }
            else
            {
                throw new DepartmentNotFoundException("Department " + departmentName + " not found.");
            }
        }

        public void GetEmployees()
        {
            Console.WriteLine("\n--- EMPLOYEE LIST ---");
            foreach (var department in Departments)
            {
                Console.WriteLine($"\nDepartment: {department.Name}");
                if (department.Employees.Count == 0)
                {
                    Console.WriteLine("No employees in this department.");
                }
                else
                {
                    foreach (var employee in department.Employees)
                    {
                        Console.WriteLine(employee);
                    }
                }
            }
        }

        public void CalculateAverageSalary(string departmentName)
        {
            departmentName = departmentName.Trim();
            
            if (Departments.Any(d => d.Name.ToLower() == departmentName.ToLower()))
            {
                var department = Departments.First(d => d.Name.ToLower() == departmentName.ToLower());
                double averageSalary = department.CalcSalaryAverage();
                Console.WriteLine($"Average salary in department {departmentName}: {averageSalary}");
            }
            else
            {
                throw new DepartmentNotFoundException("Department " + departmentName + " not found.");
            }
        }

       
    }
