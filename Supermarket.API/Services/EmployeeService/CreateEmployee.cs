using Microsoft.AspNetCore.Mvc;
using Supermarket.API.DAO;
using Supermarket.API.Data;
using Supermarket.API.Mapper;
using Supermarket.API.Models;
using Supermarket.API.Services.Employee.Validators;

namespace Supermarket.API.Service
{
    public static class CreateEmployee
    {
        public static async Task<Employee> CreateNewEmployee([FromServices] DataContext context, Employee model)
        {
            EmployeeDao employeeDao = new EmployeeDao(context);

            if (ValidatorEmployee.NameValidator(model.Name))
                throw new Exception("O nome não pode conter letras ou caracteres especiais");

            if (ValidatorEmployee.TaxNumberValidator(model.TaxNumber))
                throw new Exception("O nome não pode conter letras ou caracteres especiais");

            Task<Employee> employeeExists = employeeDao.GetByTaxNumber(model.TaxNumber);
            if (employeeExists != null)
                throw new Exception("O nome não pode conter letras ou caracteres especiais");

            try
            {
                await employeeDao.Save(model);

            }catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return model;
        }
    }
}
