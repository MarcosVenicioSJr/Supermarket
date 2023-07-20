using System.Text.RegularExpressions;

namespace Supermarket.API.Services.Employee.Validators
{
    public static class ValidatorName
    {
        public static bool NameValidator(string name)
        {
            string condition = @"^[a-zA-Z\s]+$";
            return Regex.IsMatch(name, condition);
        }
    }
}
