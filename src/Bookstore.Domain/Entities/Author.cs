using Bookstore.Domain.Entities.Contracts;
using Bookstore.Domain.ValueObjects;
using Flunt.Notifications;

namespace Bookstore.Domain.Entities
{
    public class Author : Notifiable<Notification>
    {
        public Author(int id, string name, string email)
        {
            Id = Id.Parse(id);
            Name = Name.Parse(name);
            Email = Email.Parse(email);

            AddNotifications(new CreateAuthorContract(this));
        }

        public Id Id { get; }
        public Email Email { get; }
        public Name Name { get; }
    }
}