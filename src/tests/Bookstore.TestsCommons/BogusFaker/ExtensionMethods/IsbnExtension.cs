using System.Linq;
using Bogus;
using Bookstore.Domain.ValueObjects;

namespace Bookstore.TestsCommons.BogusFaker.ExtensionMethods
{
    public static class IsbnExtension
    {
        public static Isbn Isbn(this Randomizer random)
        {
            var isbnValue = random.String2(12, "0123456789");
            var checkDigit = GenerateIsbnDigit(isbnValue);
            return new Isbn(isbnValue + checkDigit);
        }
        
        private static string GenerateIsbnDigit(string isbn)
        {
            var sum = 0;
            foreach (var (index, digit) in isbn.Select((digit, index) => (index, digit)))
            {
                sum += (digit - '0') * (index % 2 == 0 ? 1 : 3);
            }

            var checkDigit = 10 - sum % 10;
            return (checkDigit == 10 ? 0 : checkDigit).ToString();
        }
    }
}