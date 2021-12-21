using Bookstore.Domain.ExtensionMethods;

using Flunt.Notifications;
using Flunt.Validations;

using System.Collections.Generic;
using System.Linq;

namespace Bookstore.Domain.Entities.Contracts
{
    internal class CreateAuthorContract : Contract<Author>
    {
        private const string ContractName = "Author.{0}";

        public CreateAuthorContract(Author author)
        {
            Requires()
                .AddNotifications(ConcatNotifications(author));
        }

        private IReadOnlyCollection<Notification> ConcatNotifications(Author author)
        {
            var idNotifications = author.Id.Notifications.AddNotificationKeyPrefix(ContractName);
            var nameNotifications = author.Name.Notifications.AddNotificationKeyPrefix(ContractName);
            var emailNotifications = author.Email.Notifications.AddNotificationKeyPrefix(ContractName);

            return idNotifications.Concat(nameNotifications).Concat(emailNotifications).ToList();
        }
    }
}