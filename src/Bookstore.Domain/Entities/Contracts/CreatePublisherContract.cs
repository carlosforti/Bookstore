using Flunt.Validations;

namespace Bookstore.Domain.Entities.Contracts
{
    internal class CreatePublisherContract : Contract<Publisher>
    {
        private const string ContractName = "Publisher";

        public CreatePublisherContract(Publisher publisher)
        {
            Requires()
                .AddNotifications(publisher.Id.Notifications);

            Requires()
                .AddNotifications(publisher.Name.Notifications);

            Requires()
                .AddNotifications(publisher.Email.Notifications);
        }
    }
}