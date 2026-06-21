using Microsoft.AspNetCore.Mvc;
using NexusHR.Application.Services;

namespace NexusHR.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeService _service;
        public EmployeesController(EmployeeService service) { _service = service; }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());
    }
}
