using System;

namespace NixUtil
{
    public static class Misc
    {
        public static int GenerateRandomAccountNumber()
        {
            return int.Parse(RandomNumberGenerator("D5", 100000));
        }

        public static long GenerateRandomCreditCardNumber()
        {
            string str1, str2, str3, str4;
            str1 = RandomNumberGenerator("D4", 10000);
            str2 = RandomNumberGenerator("D4", 10000);
            str3 = RandomNumberGenerator("D4", 10000);
            str4 = RandomNumberGenerator("D4", 10000);

            return long.Parse($"{str1}{str2}{str3}{str4}");
        }

        private static string RandomNumberGenerator(string digits, int maxValue)
        {
            var generator = new Random();
            return generator.Next(1, maxValue).ToString(digits);
        }
    }
}
