using Flunt.Validations;

using System.Linq;

namespace Bookstore.Domain.ValueObjects.Contracts
{
    internal class CreateNameContract : Contract<Name>
    {
        private const string ContractName = "Name";
        private const string NotNullOrEmptyErrorMessage = "Name must have a value";
        private const string SizeLimitErrorMessage = "Name must be {0} to {1} characters long";
        private const int MinimumSize = 3;
        private const int MaximumSize = 300;

        public CreateNameContract(Name name)
        {
            Requires()
                .IsNotNullOrWhiteSpace(name.ToString(), ContractName, NotNullOrEmptyErrorMessage);

            if (Notifications.Any()) return;

            var nameLength = name.ToString().Length;

            Requires()
                .IsBetween(nameLength, MinimumSize, MaximumSize, ContractName, string.Format(SizeLimitErrorMessage, MinimumSize, MaximumSize));
        }
    }
}
