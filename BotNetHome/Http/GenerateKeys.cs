using System;
using System.Linq;

namespace BotNetHome.Http
{
    class GenerateKeys
    {
        public static string GenereteKeyNumber(int length)
        {
            Random random = new Random();
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string GenereteKeyAlphNumeric(bool ToUpper, int length)
        {
            Random random = new Random();
            string words = "abcdfghijlmnopqrstuvxzwky";
            if (ToUpper)
            {
                words.ToUpper();
            }
            string chars = "0123456789" + words;
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
