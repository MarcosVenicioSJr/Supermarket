namespace Supermarket.API.Services.EmployeeService
{
    public class EmployeeResponse
    {
        public string Message { get; set; }
        public Models.Employee Employee { get; set; }

        public EmployeeResponse(Models.Employee Employee)
        {
            this.Employee = Employee;
        }
    }
}
