namespace Supermarket.API.Services.EmployeeService
{
    public class EmployeeResponse
    {
        public EmployeeResponse() { }

        public string Message { get; set; }
        public Models.Employee Employee { get; set; }
        public List<Models.Employee> Employees { get; set; }

        public EmployeeResponse(Models.Employee Employee)
        {
            this.Employee = Employee;
        }
        public EmployeeResponse(List<Models.Employee> Employees)
        {
            this.Employees = Employees;
        }
    }
}
