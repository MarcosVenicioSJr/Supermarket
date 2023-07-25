using System.Text.RegularExpressions;

namespace Supermarket.API.Services.Employee.Validators
{
    public static class ValidatorEmployee
    {
        public static bool NameValidator(string name)
        {
            string condition = @"^[a-zA-Z]+(\s[a-zA-Z]+)*$";
            return Regex.IsMatch(name, condition);
        }

        public static bool TaxNumberValidator(string taxNumber)
        {
            bool allDigitsEqual = true;
            for (int i = 1; i < 11; i++)
            {
                if (taxNumber[i] != taxNumber[0])
                {
                    allDigitsEqual = false;
                    break;
                }
            }

            if (allDigitsEqual)
                return false;

            // Calcular o primeiro dígito verificador
            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                if (!char.IsDigit(taxNumber[i]))
                    return false;

                sum += (taxNumber[i] - '0') * (10 - i);
            }

            int firstVerifier = 11 - (sum % 11);
            if (firstVerifier >= 10)
                firstVerifier = 0;

            // Verificar o primeiro dígito verificador
            if (taxNumber[9] - '0' != firstVerifier)
                return false;

            // Calcular o segundo dígito verificador
            sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sum += (taxNumber[i] - '0') * (11 - i);
            }

            int secondVerifier = 11 - (sum % 11);
            if (secondVerifier >= 10)
                secondVerifier = 0;

            // Verificar o segundo dígito verificador
            if (taxNumber[10] - '0' != secondVerifier)
                return false;

            return true;
        }
    }
}
