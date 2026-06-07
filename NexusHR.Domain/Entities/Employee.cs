using System;
using System.ComponentModel.DataAnnotations;

namespace NexusHR.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string IdentityUserId { get; set; } // Reference to AspNetUser
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
        public int? ManagerId { get; set; }
        public Employee Manager { get; set; }
        public string EmploymentType { get; set; }
        public DateTime StartDate { get; set; }
        public string Status { get; set; }
    }
}
