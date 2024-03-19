using Keeper.Library.Dto;
using Keeper.Library.Services;
using Keeper.Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Keeper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployees()
        {
            return await _employeeService.GetEmployees();
        }

        // GET: api/Employee/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _employeeService.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }
            return employee;
        }

        // POST: api/Employee
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(EmployeeCreationDto dto)
        {
            int id = await _employeeService.Add(dto);
            return CreatedAtAction("GetEmployee", new { id = id }, dto);
        }

        // PUT: api/Employee/{id}
        [HttpPut]
        public async Task<IActionResult> PutEmployee(int id, EmployeeCreationDto dto)
        {

            await _employeeService.Edit(id, dto);
            return NoContent();
        }

        // DELETE: api/Employee/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            Employee employee = await _employeeService.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }

            await _employeeService.Remove(id);

            return NoContent();

        }

    }
}
