using Supermarket.API.DAO;
using Supermarket.API.Data;

namespace Supermarket.API.Services.EmployeeService
{
    public static class Resignation
    {
        public async static Task ResignationEmployee(DataContext context, string code)
        {
            EmployeeDao employeeDao = new EmployeeDao(context);

            Task<Models.Employee> result = employeeDao.GetByCode(code);
            if (result == null)
                throw new Exception("Funcionário não encontrado, tente outro código");

            try
            {
               await employeeDao.Update(result.Result);
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.ToString());
            }

        }
    }
}
