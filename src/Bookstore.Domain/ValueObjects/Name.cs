using Bookstore.Domain.ValueObjects.Contracts;

using Flunt.Notifications;

namespace Bookstore.Domain.ValueObjects
{
    public class Name : Notifiable<Notification>
    {
        private readonly string _name;

        public Name(string name)
        {
            _name = name;
            AddNotifications(new CreateNameContract(this));
        }

        public override string ToString() => _name;

        public static bool TryParse(string value, out Name result)
        {
            result = Parse(value);
            return result.IsValid;
        }

        public static Name Parse(string value) => new Name(value);

        public static implicit operator Name(string value) => Parse(value);
    }
}
