using Bookstore.Domain.Entities.Contracts;
using Bookstore.Domain.ValueObjects;

using Flunt.Notifications;

using System;

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

        public override bool Equals(object? obj)
        {
            if (!(obj is Store)) return false;

            return ((Store)obj).GetHashCode() == GetHashCode();
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Email);
        }
    }
}
