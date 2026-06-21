using NexusHR.Application.Services;
using Microsoft.EntityFrameworkCore;
using NexusHR.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<EmployeeService>();

// Configure Database
builder.Services.AddDbContext<NexusDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();