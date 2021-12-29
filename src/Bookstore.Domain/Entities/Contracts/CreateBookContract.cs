using Bookstore.Domain.ExtensionMethods;

using Flunt.Notifications;
using Flunt.Validations;

using System.Collections.Generic;
using System.Linq;

namespace Bookstore.Domain.Entities.Contracts
{
    internal class CreateBookContract : Contract<Book>
    {
        private const string ContractName = "Book.{0}";

        public CreateBookContract(Book book)
        {
            Requires()
                .AddNotifications(ConcatNotifications(book));
        }

        private IReadOnlyCollection<Notification> ConcatNotifications(Book book)
        {
            var idNotifications = book.Id.Notifications.AddNotificationKeyPrefix(ContractName);
            var nameNotifications = book.Name.Notifications.AddNotificationKeyPrefix(ContractName);
            var authorNotifications = book.Author.Notifications.AddNotificationKeyPrefix(ContractName);
            var publisherNotifications = book.Publisher.Notifications.AddNotificationKeyPrefix(ContractName);
            var isbnNotifications = book.Isbn.Notifications.AddNotificationKeyPrefix(ContractName);

            return idNotifications.Concat(nameNotifications)
                                  .Concat(authorNotifications)
                                  .Concat(publisherNotifications)
                                  .Concat(isbnNotifications)
                                  .ToList();
        }
    }
}
