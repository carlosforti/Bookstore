using Bookstore.Domain.ValueObjects.Contracts;

using Flunt.Notifications;

namespace Bookstore.Domain.ValueObjects
{
    public class Isbn : Notifiable<Notification>
    {
        private readonly string _isbn;

        public Isbn(string isbn)
        {
            _isbn = (isbn ?? "").Replace("-", "").Replace(" ", "");

            AddNotifications(new CreateIsbnContract(this));
        }

        public override string ToString() => _isbn;

        public static Isbn Parse(string value) => new Isbn(value);

        public static bool TryParse(string value, out Isbn result)
        {
            result = Parse(value);
            return result.IsValid;
        }

        public static implicit operator string(Isbn value) => value.ToString();
    }
}
