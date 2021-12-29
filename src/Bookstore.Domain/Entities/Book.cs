using Bookstore.Domain.Entities.Contracts;
using Bookstore.Domain.ValueObjects;

using Flunt.Notifications;

using System;

namespace Bookstore.Domain.Entities
{
    public class Book : Notifiable<Notification>
    {
        public Book(int id, string name, Author author, Publisher publisher, string isbn)
        {
            Id = Id.Parse(id);
            Name = Name.Parse(name);
            Author = author;
            Publisher = publisher;
            Isbn = Isbn.Parse(isbn);

            AddNotifications(new CreateBookContract(this));
        }

        public Id Id { get; }
        public Name Name { get; }
        public Author Author { get; }
        public Publisher Publisher { get; }
        public Isbn Isbn { get; }

        public override bool Equals(object? obj)
        {
            if (!(obj is Book)) return false;
            return ((Book)obj).GetHashCode() == GetHashCode();
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Author, Publisher, Isbn);
        }
    }
}
