using Bookstore.Domain.Entities.Contracts;
using Bookstore.Domain.ValueObjects;

using Flunt.Notifications;

using System;

namespace Bookstore.Domain.Entities
{
    public class Publisher : Notifiable<Notification>
    {
        public Publisher(int id, string name, string email)
        {
            Id = Id.Parse(id);
            Name = Name.Parse(name);
            Email = Email.Parse(email);

            AddNotifications(new CreatePublisherContract(this));
        }

        public Id Id { get; }
        public Email Email { get; }
        public Name Name { get; }

        public override bool Equals(object? obj)
        {
            if (!(obj is Publisher)) return false;

            return ((Publisher)obj).GetHashCode() == GetHashCode();
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Email, Name);
        }
    }
}