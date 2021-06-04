using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NixUtil
{
    public static class Misc
    {
        public static int GenerateRandomAccountNumber()
        {
            return int.Parse(RandomNumberGenerator("D5"));
        }

        public static long GenerateRandomCreditCardNumber()
        {
            string str1, str2, str3, str4;
            str1 = RandomNumberGenerator("D4");
            str2 = RandomNumberGenerator("D4");
            str3 = RandomNumberGenerator("D4");
            str4 = RandomNumberGenerator("D4");

            return long.Parse($"{str1}{str2}{str3}{str4}");
        }

        private static string RandomNumberGenerator(string digits)
        {
            var generator = new Random();
            return generator.Next(1, 1000000000).ToString(digits);
        }
    }
}
