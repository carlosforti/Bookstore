using Bookstore.Domain.ValueObjects.Contracts;

using Flunt.Notifications;

namespace Bookstore.Domain.ValueObjects
{
    public class Email : Notifiable<Notification>
    {
        private readonly string _email;

        public Email(string email)
        {
            _email = email;
            AddNotifications(new CreateEmailContract(this));
        }

        public override string ToString() => _email;

        public static Email Parse(string value) => new Email(value);

        public static bool TryParse(string value, out Email result)
        {
            result = new Email(value);
            return result.IsValid;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null
                || (!(obj is Email) && !(obj is string))) return false;
            
            var stringObj = obj.ToString();
            return ((Email)stringObj).GetHashCode() == _email.GetHashCode();
        }

        public override int GetHashCode()
        {
            return _email.GetHashCode();
        }

        public static implicit operator Email(string value) => Parse(value);
        public static implicit operator string(Email value) => value.ToString();
    }
}
