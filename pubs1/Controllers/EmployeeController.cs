using Microsoft.AspNetCore.Mvc;
using pubs1.Models;
using pubs1.Services;
using System.Collections.Generic;

namespace pubs1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/employee
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAllEmployees()
        {
            var employees = _employeeService.GetAllEmployees();
            return Ok(employees);
        }

        // GET: api/employee/{id}
        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployeeById(string id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        // POST: api/employee
        [HttpPost]
        public ActionResult AddEmployee([FromBody] Employee employee)
        {
            _employeeService.AddEmployee(employee);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.EmpId }, employee);
        }

        // PUT: api/employee/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateEmployee(string id, [FromBody] Employee employee)
        {
            var existingEmployee = _employeeService.GetEmployeeById(id);
            if (existingEmployee == null)
            {
                return NotFound();
            }

            employee.EmpId = id; // Đảm bảo ID không thay đổi
            _employeeService.UpdateEmployee(employee);
            return NoContent();
        }

        // DELETE: api/employee/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteEmployee(string id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }

            _employeeService.DeleteEmployee(id);
            return NoContent();
        }
    }
}
