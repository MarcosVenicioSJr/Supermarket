using Supermarket.API.Models;

namespace Supermarket.API.Mapper
{
    public static class EmployeeMapper
    {
        public static Employee EmployeeDTO(Employee model)
        {
            Employee employee = new Employee()
            {
                Name = model.Name,
                DateOfAdmission = model.DateOfAdmission,
                DateOfDemission = model.DateOfDemission,
                Position = model.Position,
                Salary = model.Salary,
            };

            return employee;
        }
    }
}
