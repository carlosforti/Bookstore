using Flunt.Validations;

namespace Bookstore.Domain.Entities.Contracts
{
    internal class CreateStoreContract: Contract<Store>
    {
        private const string ContractName = "Store";

        public CreateStoreContract(Store store)
        {
            Requires()
                .AddNotifications(store.Id.Notifications);

            Requires()
                .AddNotifications(store.Name.Notifications);

            Requires()
                .AddNotifications(store.Email.Notifications);
        }
    }
}
