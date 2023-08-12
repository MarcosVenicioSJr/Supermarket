using Microsoft.EntityFrameworkCore;
using Supermarket.API.Data;
using Supermarket.API.Models;

namespace Supermarket.API.DAO
{
    public class EmployeeDao
    {
        private readonly DataContext _context;
        public EmployeeDao(DataContext context)
        {
            _context = context;
        }

        public async Task<Employee> GetById(int id)
        {
            Employee? result = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<Employee> GetByTaxNumber(string taxNumber)
        {
            Employee result = await _context.Employees.FirstOrDefaultAsync(x => x.TaxNumber == taxNumber);
            return result;
        }

        public async Task<Employee> GetByCode(string code)
        {
            Employee? result = await _context.Employees.FirstOrDefaultAsync(x => x.Code == code);
            return result;
        }


        public async Task Save(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }

        private async void ModifyDateDemission()
        {

        }

        public async Task Update(Employee employee)
        {
            employee.DateOfDemission = DateTime.Now;
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }
    }
}
