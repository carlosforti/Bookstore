using Flunt.Validations;

using System.Linq;

namespace Bookstore.Domain.ValueObjects.Contracts
{
    internal class CreateIsbnContract : Contract<Isbn>
    {
        private const string ContractName = "ISBN";
        private const string InvalidIsbn = "ISBN is invalid";
        private const string NotNullOrEmptyErrorMessage = "ISBN must have a value";
        private const int MinimumSize = 10;
        private const int MaximumSize = 13;

        public CreateIsbnContract(Isbn isbn)
        {
            Requires()
                .IsNotNullOrWhiteSpace(isbn.ToString(), ContractName, NotNullOrEmptyErrorMessage);

            if (Notifications.Any()) return;

            Requires()
                .IsTrue(ValidIsbn(isbn), ContractName, InvalidIsbn);
        }

        private bool ValidIsbn(Isbn isbn)
        {
            if (isbn.ToString().Length != MinimumSize
                && isbn.ToString().Length != MaximumSize) return false;

            return isbn.ToString().Length == 10
                ? ValidIsbn10(isbn)
                : ValidIsbn13(isbn);
        }

        private bool ValidIsbn10(Isbn isbn)
        {
            string isbnValue = isbn;

            if (!long.TryParse(isbnValue[..(MinimumSize - 2)], out var _)) return false;

            var sum = 0;
            for (var i = 0; i < 9; i++)
            {
                var digit = GetDigit(isbnValue[i]);
                sum += digit * (10 - i);
            }

            var last = isbnValue[9];

            if (last != 'X' && (last < '0' || last > '9')) return false;

            sum += (last == 'X') ? 10 : GetDigit(last);

            return sum % 11 == 0;
        }

        private bool ValidIsbn13(Isbn isbn)
        {
            string isbnValue = isbn;

            var sum = 0;

            foreach (var (index, digit) in isbnValue.Select((digit, index) => (index, digit)))
            {
                if (char.IsDigit(digit))
                    sum += (digit - '0') * (index % 2 == 0 ? 1 : 3);
                else
                    return false;
            }

            return (sum % 10) == 0;
        }

        private int GetDigit(char value) => value - '0';
    }
}
