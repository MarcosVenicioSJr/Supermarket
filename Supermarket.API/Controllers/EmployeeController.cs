using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Supermarket.API.Data;
using Supermarket.API.Mapper;
using Supermarket.API.Models;
using Supermarket.API.Service;
using Supermarket.API.Services;
using Supermarket.API.Services.Employee;
using Supermarket.API.Services.EmployeeService;

namespace Supermarket.API.Controllers
{
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Employee>> GetById([FromServices] DataContext context, int id)
        {
            Employee? employee = await context.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (employee == null)
                return NotFound(new { message = "Produto não encontrado" });

            return Ok(employee);
        }

        [HttpGet]
        [Route("GetAllEmployee")]
        public async Task<ActionResult<List<Employee>>> GetAll([FromServices] DataContext context)
        {
            List<Employee> employees = await context.Employees.AsNoTracking().ToListAsync();

            return Ok(employees);
        }

        [HttpPost]
        [Route("CreateEmployee")]
        public async Task<ActionResult<Employee>> Post([FromServices] DataContext context, [FromBody] EmployeeRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Employee employeeDTO = EmployeeMapper.EmployeeDTO(model);
            Employee employee = await CreateEmployee.CreateNewEmployee(context, employeeDTO);

            EmployeeResponse response = new EmployeeResponse()
            {
                Message = "Funcionário registrado com sucesso!",
                Employee = employee
            };

            return Ok(response);
        }
    }
}
