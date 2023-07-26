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
            try
            {

                Employee? employee = await context.Employees.FirstOrDefaultAsync(x => x.Id == id);
                if (employee == null)
                    return NotFound(new { message = "Funcionário não encontrado." });

                EmployeeResponse response = new EmployeeResponse(employee)
                {
                    Message = "Funcionário encontrado com sucesso!",
                    Employee = employee
                };

                return Ok(response);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetAllEmployee")]
        public async Task<ActionResult<List<Employee>>> GetAll([FromServices] DataContext context)
        {
            try
            {
                List<Employee> employees = await context.Employees.AsNoTracking().ToListAsync();

                var result = new
                {
                    Message = "Lista encontrada com sucesso.",
                    Employees = employees
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        [Route("CreateEmployee")]
        public async Task<ActionResult<Employee>> Post([FromServices] DataContext context, [FromBody] EmployeeRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                Employee employeeDTO = EmployeeMapper.EmployeeDTO(model);
                Employee employee = await CreateEmployee.CreateNewEmployee(context, employeeDTO);

                EmployeeResponse response = new EmployeeResponse(employee)
                {
                    Message = "Funcionário registrado com sucesso!",
                    Employee = employee
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        [Route("ResignationEmployee/{code}")]
        public async Task<ActionResult<Employee>> Post([FromServices] DataContext context, string code)
        {
            try
            {
                Resignation.ResignationEmployee(context, code);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
