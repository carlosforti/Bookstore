using Bookstore.Domain.ValueObjects.Contracts;

using Flunt.Notifications;

namespace Bookstore.Domain.ValueObjects
{
    public class Id : Notifiable<Notification>
    {
        private readonly int _id;

        public Id(int id)
        {
            _id = id;

            AddNotifications(new CreateIdContract(this));
        }

        public int Value => _id;

        public static Id Parse(int value) => new Id(value);

        public static bool TryParse(int value, out Id result)
        {
            result = new Id(value);
            return result.IsValid;
        }
    }
}
