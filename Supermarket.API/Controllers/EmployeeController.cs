using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Supermarket.API.Data;
using Supermarket.API.Mapper;
using Supermarket.API.Models;
using Supermarket.API.Service;
using Supermarket.API.Services.EmployeeService;

namespace Supermarket.API.Controllers
{
    public class EmployeeController : ControllerBase
    {
        private EmployeeResponse CreateEmployeeResponse(Employee employee, string message)
        {
            return new EmployeeResponse(employee)
            {
                Message = message,
                Employee = employee
            };
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Employee>> GetById([FromServices] DataContext context, int id)
        {
            try
            {
                Employee employee = await GetEmployeeById.GetByIdAsync(context, id);

                if (employee == null)
                    return NotFound(new { message = "Funcionário não encontrado." });

                return Ok(CreateEmployeeResponse(employee, "Funcionário encontrado com sucesso!"));
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
                    Message = "Segue lista de funcionários.",
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

                return Ok(CreateEmployeeResponse(employee, "Funcionário registrado com sucesso!"));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("ResignationEmployee/{code}")]
        public async Task<ActionResult<Employee>> Post([FromServices] DataContext context, string code)
        {
            try
            {
                string result = await Resignation.ResignationEmployee(context, code);

                return Ok(new EmployeeResponse()
                {
                    Message = $"Funcionário com o código {result} foi demitido com sucesso.",
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
