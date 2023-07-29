using Supermarket.API.DAO;
using Supermarket.API.Data;

namespace Supermarket.API.Services.EmployeeService
{
    public static class Resignation
    {
        public async static Task<string> ResignationEmployee(DataContext context, string code)
        {
            EmployeeDao employeeDao = new EmployeeDao(context);

            Models.Employee employee = await employeeDao.GetByCode(code);
            if (employee == null)
                throw new Exception("Funcionário não encontrado, tente outro código");

            if (employee.DateOfDemission != null)
                throw new Exception("Funcionário já foi demitido");

            try
            {
                await employeeDao.Update(employee);
                return code;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
