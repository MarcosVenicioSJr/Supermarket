using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Supermarket.API.DAO;
using Supermarket.API.Data;
using Supermarket.API.Models;

namespace Supermarket.API.Services.EmployeeService
{
    public static class GetEmployeeById
    {
        public static async Task<Models.Employee> GetByIdAsync([FromServices] DataContext context, int id)
        {
            try
            {
                EmployeeDao employeeDao = new EmployeeDao(context);
                Models.Employee? employee = await employeeDao.GetById(id);
                return employee;
            }catch(Exception ex)
            {
                throw;
            }
        }


    }
}
