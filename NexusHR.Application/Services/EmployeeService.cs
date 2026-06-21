using System.Collections.Generic;
using System.Linq;
using NexusHR.Application.DTOs;
using NexusHR.Infrastructure.Context;

namespace NexusHR.Application.Services
{
    public class EmployeeService
    {
        private readonly NexusDbContext _context;
        public EmployeeService(NexusDbContext context) { _context = context; }

        public IEnumerable<EmployeeDto> GetAll()
        {
            return _context.Employees.Select(e => new EmployeeDto {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                JobTitle = e.JobTitle,
                DepartmentName = e.Department.Name
            }).ToList();
        }
    }
}
