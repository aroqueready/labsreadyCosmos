using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ready.labs.Models;
using ready.labs.Services;

namespace ready.labs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employee;
        public EmployeeController(IEmployeeRepository employee)
        {
            _employee = employee;
        }

        [HttpGet, Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee()
        {
            var employee = await _employee.GetAllEmployees();
            return Ok(employee);
        }
    }
}
