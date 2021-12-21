using Flunt.Validations;

namespace Bookstore.Domain.ValueObjects.Contracts
{
    internal class CreateEmailContract: Contract<Email>
    {
        private const string ContractName = "Email";
        private const string InvalidEmailMessage = "Invalid e-mail address";

        public CreateEmailContract(Email email)
        {
            Requires()
                .IsEmail(email.ToString(), ContractName, InvalidEmailMessage);
        }
    }
}
