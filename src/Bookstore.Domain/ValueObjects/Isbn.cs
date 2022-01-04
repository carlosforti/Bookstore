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

        public override bool Equals(object? obj)
        {
            if (obj == null
                || (!(obj is Isbn) && !(obj is string))) return false;

            var stringObj = obj.ToString();
            return ((Isbn)stringObj).ToString() == _isbn;
        }

        public override int GetHashCode()
        {
            return _isbn.GetHashCode();
        }

        public static implicit operator string(Isbn value) => value.ToString();
        public static implicit operator Isbn(string value) => Parse(value);
    }
}
