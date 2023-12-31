﻿using Supermarket.API.Models;
using Supermarket.API.Services.EmployeeService;

namespace Supermarket.API.Mapper
{
    public static class EmployeeMapper
    {
        public static Employee EmployeeDTO(EmployeeRequestModel model)
        {
            Employee employee = new Employee()
            {
                Name = model.Name,
                Position = model.Position,
                DateOfAdmission = model.DateOfAdmission,
                Salary = model.Salary,
                TaxNumber = model.TaxNumber,
                Code = Guid.NewGuid().ToString(),
                DateOfDemission = null
            };

            return employee;
        }
    }
}
