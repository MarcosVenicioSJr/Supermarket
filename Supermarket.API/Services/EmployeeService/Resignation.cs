using Supermarket.API.DAO;
using Supermarket.API.Data;

namespace Supermarket.API.Services.EmployeeService
{
    public static class Resignation
    {
        public async static Task ResignationEmployee(DataContext context, string code)
        {
            EmployeeDao employeeDao = new EmployeeDao(context);

            var result = await employeeDao.GetByCode(code);
            if (result == null)
                throw new Exception("Funcionário não encontrado, tente outro código");

            try
            {
                //await employeeDao.Update(result);
                //return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }
    }
}
