using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Data;
using Supermarket.API.Mapper;
using Supermarket.API.Models;
using Supermarket.API.Services.Employee.Validators;

namespace Supermarket.API.Service
{
    public static class CreateEmployee
    {
        public static void CreateNewEmployee([FromServices] DataContext context, Employee model)
        {
            if (ValidatorName.NameValidator(model.Name))
                throw new Exception("O nome não pode conter letras ou caracteres especiais");


        }
    }
}
