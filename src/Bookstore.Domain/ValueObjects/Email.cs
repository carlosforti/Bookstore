using Bookstore.Domain.ValueObjects.Contracts;

using Flunt.Notifications;

namespace Bookstore.Domain.ValueObjects
{
    public class Email: Notifiable<Notification>
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

        public static implicit operator Email(string value) => Parse(value);
    }
}
