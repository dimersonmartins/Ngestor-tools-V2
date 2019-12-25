using System;
using System.Linq;

namespace Helpers
{
    public class GenerateKey
    {
        public string NumberKey(int length)
        {
            Random random = new Random();
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public string AlphNumeric(int length)
        {
            Random random = new Random();
            const string chars = "abcdefghijlmnopqrstuvxzywk0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public string Words(int length)
        {
            Random random = new Random();
            const string chars = "abcdefghijlmnopqrstuvxzywk";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
