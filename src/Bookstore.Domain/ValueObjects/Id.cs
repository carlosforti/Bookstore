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

        public override bool Equals(object? obj)
        {
            if (obj == null || (!(obj is Id) && !(obj is int))) return false;

            var intObj = obj is int 
                ? (int)obj 
                : ((Id)obj).Value;
            return intObj == _id;
        }

        public override int GetHashCode()
        {
            return _id.GetHashCode();
        }

        public override string ToString()
        {
            return _id.ToString();
        }

        public static implicit operator int(Id id) => id.Value;
        public static implicit operator Id(int id) => Parse(id);
    }
}
