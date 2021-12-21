using Bookstore.Domain.ValueObjects;

using FluentAssertions;

using Flunt.Notifications;

using Xunit;

namespace Bookstore.UnitTests.Domain.ValueObjects
{
    public class EmailsTests
    {
        private const string ContractName = "Email";
        private const string InvalidEmailMessage = "Invalid e-mail address";
        private const string ValidEmail = "thisis@validemail.com";
        private const string InvalidEmail = "notanemail.com";

        [Fact]
        public void CreateEmail_ShouldBeSuccess_WithoutNotifications()
        {
            var email = new Email(ValidEmail);
            email.IsValid.Should().BeTrue();
            email.Notifications.Should().BeEmpty();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData(InvalidEmail)]
        public void CreateEmail_ShouldFail_WithInvalidEmailErrorMessage(string input)
        {
            var expectedNotification = new Notification(ContractName, InvalidEmailMessage);
            var email = new Email(input);
            email.IsValid.Should().BeFalse();
            email.Notifications.Should().ContainEquivalentOf(expectedNotification);
        }

        [Fact]
        public void ParseEmail_ShouldBeSuccess_WithoutNotifications()
        {
            var email = Email.Parse(ValidEmail);
            email.IsValid.Should().BeTrue();
            email.Notifications.Should().BeEmpty();
        }


        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData(InvalidEmail)]
        public void ParseEmail_ShouldFail_WithInvalidEmailMessage(string input)
        {
            var expectedNotification = new Notification(ContractName, InvalidEmailMessage);
            var email = Email.Parse(input);
            email.IsValid.Should().BeFalse();
            email.Notifications.Should().ContainEquivalentOf(expectedNotification);
        }

        [Fact]
        public void TryParseEmail_ShouldBeSuccess_WithoutNotifications()
        {
            var ok = Email.TryParse(ValidEmail, out var email);
            ok.Should().BeTrue();
            email.IsValid.Should().BeTrue();
            email.Notifications.Should().BeEmpty();
        }


        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData(InvalidEmail)]
        public void TryParseEmail_ShouldFail_WithInvalidEmailErrorMessage(string input)
        {
            var expectedNotification = new Notification(ContractName, InvalidEmailMessage);
            var ok = Email.TryParse(input, out var email);
            ok.Should().BeFalse();
            email.IsValid.Should().BeFalse();
            email.Notifications.Should().ContainEquivalentOf(expectedNotification);
        }

        [Fact]
        public void ImplicitParseEmail_ShouldBeSuccess_WithoutNotifications()
        {
            var email = (Email)ValidEmail;
            email.IsValid.Should().BeTrue();
            email.Notifications.Should().BeEmpty();
        }


        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData(InvalidEmail)]
        public void ImplicitParseEmail_ShouldFail_WithInvalidEmailErrorMessage(string input)
        {
            var expectedNotification = new Notification(ContractName, InvalidEmailMessage);
            var email = (Email)input;
            email.IsValid.Should().BeFalse();
            email.Notifications.Should().ContainEquivalentOf(expectedNotification);
        }
    }
}
