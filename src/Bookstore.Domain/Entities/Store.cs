using Bookstore.Domain.Entities.Contracts;
using Bookstore.Domain.ValueObjects;

using Flunt.Notifications;

namespace Bookstore.Domain.Entities
{
    public class Store : Notifiable<Notification>
    {
        public Store(int id, string name, string email)
        {
            Id = Id.Parse(id);
            Name = Name.Parse(name);
            Email = Email.Parse(email);

            AddNotifications(new CreateStoreContract(this));
        }

        public Id Id { get; }
        public Name Name { get; }
        public Email Email { get; }
    }
}
