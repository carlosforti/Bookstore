using Bookstore.Domain.ValueObjects;

using FluentAssertions;

using Flunt.Notifications;

using Xunit;

namespace Bookstore.UnitTests.Domain.ValueObjects
{
    public class IsbnTests
    {
        private const string ContractName = "ISBN";
        private const string InvalidIsbn = "ISBN is invalid";
        private const string NotNullOrEmptyErrorMessage = "ISBN must have a value";

        [Theory]
        [InlineData("978-987-33-0311-1")]
        [InlineData("9789873303111")]
        [InlineData("1-56619-909-3")]
        [InlineData("1566199093")]
        public void CreateIsbn_ShouldBeSuccess_WithoutNotifications(string input)
        {
            var isbn = Isbn.Parse(input);
            isbn.IsValid.Should().BeTrue();
            isbn.Notifications.Should().BeEmpty();
        }

        [Theory]
        [InlineData("978-987-33-0311-2")]
        [InlineData("9789873303112")]
        [InlineData("1-56619-909-2")]
        [InlineData("1566199092")]
        [InlineData("X789873303112")]
        [InlineData("X566199092")]
        [InlineData("156619909A")]
        [InlineData("156619909!")]
        public void CreateIsbn_ShouldFail_WithNotification_WhenInvalidIsbn(string input)
        {
            var expectedNotification = new Notification(ContractName, InvalidIsbn);
            var isbn = new Isbn(input);
            isbn.IsValid.Should().BeFalse();
            isbn.Notifications.Should().NotBeEmpty();
            isbn.Notifications.Should().ContainEquivalentOf(expectedNotification);
        }

        [Theory]
        [InlineData("123456789012")]
        [InlineData("123456789")]
        public void CreateIsbn_ShouldFail_WithNotification_WhenInvalidSize(string input)
        {
            var expectedNotification = new Notification(ContractName,
                                                        InvalidIsbn);
            var isbn = Isbn.Parse(input);
            isbn.IsValid.Should().BeFalse();
            isbn.Notifications.Should().ContainEquivalentOf(expectedNotification);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void CreateIsbn_ShouldFail_WithNullOrEmptyNotification_WhenNullOrEmpty(string input)
        {
            var expectedNotification = new Notification(ContractName,
                                                        NotNullOrEmptyErrorMessage);
            var isbn = Isbn.Parse(input);
            isbn.IsValid.Should().BeFalse();
            isbn.Notifications.Should().ContainEquivalentOf(expectedNotification);
        }

        [Fact]
        public void TryParseIsbn_ShouldBeSuccess_WithoutNotification()
        {
            var parsed = Isbn.TryParse("978-987-33-0311-1", out var isbn);
            parsed.Should().BeTrue();
            isbn.IsValid.Should().BeTrue();
            isbn.Notifications.Should().BeEmpty();
        }

        [Fact]
        public void TryParseIsbn_ShouldFail_WithNotification()
        {
            var parsed = Isbn.TryParse("978-987-33-0311-2", out var isbn);
            parsed.Should().BeFalse();
            isbn.IsValid.Should().BeFalse();
            isbn.Notifications.Should().NotBeEmpty();
        }

        [Fact]
        public void ImplicitConversionToString_ShouldBeSuccess()
        {
            var isbn = Isbn.Parse("9789873303112");
            ((string)isbn).Should().Be("9789873303112");
        }
    }
}
