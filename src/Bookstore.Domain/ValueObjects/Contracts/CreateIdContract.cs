using Flunt.Validations;

namespace Bookstore.Domain.ValueObjects.Contracts
{
    internal class CreateIdContract : Contract<Id>
    {
        private const string ContractName = "Id";
        private const string InvalidIdErrorMessage = "Id must be greater or equals than zero";
        private const int IdComparer = 0;

        public CreateIdContract(Id id)
        {
            Requires()
                .IsGreaterOrEqualsThan(id.Value, IdComparer, ContractName, InvalidIdErrorMessage);
        }
    }
}
