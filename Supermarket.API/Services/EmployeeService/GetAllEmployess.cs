using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Supermarket.API.DAO;
using Supermarket.API.Data;

namespace Supermarket.API.Services.EmployeeService
{
    public static class GetAllEmployess
    {
        public static async Task<List<Models.Employee>> GetAll(DataContext context)
        {
            try
            {
                EmployeeDao employeeDao = new EmployeeDao(context);
                List<Models.Employee> employess = await employeeDao.GetAll();
                return employess;
            }catch (Exception ex)
            {
                throw;
            }
            
        }
    }
}
