using System.Text.RegularExpressions;

namespace Supermarket.API.Services.ProductService.ValidatorBarCode
{
    internal static class BarCodeValidator
    {
        internal static bool ValidateBarCode(string barCode)
        {
            var regex = "^[0-9]{13}$";
            Match match = Regex.Match(barCode, regex, RegexOptions.IgnoreCase);
            if (!match.Success)
                return false;

            int[] numbers = new int[barCode.Length];
            for (int i = 0; i < barCode.Length; i++)
                numbers[i] = int.Parse(barCode[i].ToString());

            int sumPairs = numbers[1] + numbers[3] + numbers[5] + numbers[7] + numbers[9] + numbers[11];
            int sumOdds = numbers[0] + numbers[2] + numbers[4] + numbers[6] + numbers[8] + numbers[10];
            int result = (sumPairs + sumOdds) * 3;
            int digitVerificator = (result - 10) % 10;
            return numbers[12].Equals(digitVerificator);
        }
    }
}
