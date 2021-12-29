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

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Name) || !(obj is string)) return false;
            return ((Name)obj).ToString() == _name;
        }

        public override int GetHashCode()
        {
            return _name.GetHashCode();
        }

        public static implicit operator Name(string value) => Parse(value);

        public static implicit operator string(Name value) => value.ToString();
    }
}
