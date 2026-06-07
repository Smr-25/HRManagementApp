using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NexusHR.Domain.Entities;

namespace NexusHR.Infrastructure.Context
{
    public class NexusDbContext : IdentityDbContext
    {
        public NexusDbContext(DbContextOptions<NexusDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
