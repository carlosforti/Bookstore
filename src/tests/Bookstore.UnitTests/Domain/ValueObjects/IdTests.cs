using Bookstore.Domain.ValueObjects;

using FluentAssertions;

using Flunt.Notifications;

using Xunit;

namespace Bookstore.UnitTests.Domain.ValueObjects
{
    public class IdTests
    {
        private const string ContractName = "Id";
        private const string InvalidIdErrorMessage = "Id must be greater or equals than zero";
        private const int IdComparer = 0;

        [Fact]
        public void CreateId_ShouldBeSuccess_WithoutNotification()
        {
            var id = new Id(0);
            id.IsValid.Should().BeTrue();
            id.Notifications.Should().BeEmpty();
        }

        [Fact]
        public void CreateId_ShouldFail_WithNotification()
        {
            var expectedNotification = new Notification(ContractName, string.Format(InvalidIdErrorMessage, IdComparer));
            var id = new Id(-1);
            id.IsValid.Should().BeFalse();
            id.Notifications.Should().ContainEquivalentOf(expectedNotification);
        }

        [Fact]
        public void TryParseId_ShouldBeSuccess_WithoutNotification()
        {
            var parsed = Id.TryParse(0, out var id);
            parsed.Should().BeTrue();
            id.IsValid.Should().BeTrue();
            id.Notifications.Should().BeEmpty();
        }

        [Fact]
        public void TryParseId_ShouldFail_WithNotifications()
        {
            var expectedNotification = new Notification(ContractName, string.Format(InvalidIdErrorMessage, IdComparer));
            var parsed = Id.TryParse(-1, out var id);
            parsed.Should().BeFalse();
            id.IsValid.Should().BeFalse();
            id.Notifications.Should().ContainEquivalentOf(expectedNotification);
        }

        [Fact]
        public void ImplicitParseToInt_ShouldBeSuccess_WithoutNotifications()
        {
            var expectedId = 1;
            var id = Id.Parse(expectedId);

            var resultId = (int)id;

            resultId.Should().Be(expectedId);
        }

        [Fact]
        public void ImplicitParseIntToId_ShouldBeSuccess_WithoutNotification()
        {
            var expected = new Id(1);
            var result = (Id)1;

            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Equals_ShoudBeTrue_WhenComparingWithId()
        {
            var id = new Id(1);
            var otherId = new Id(1);
            id.Equals(otherId).Should().BeTrue();
        }

        [Fact]
        public void Equals_ShoudBeTrue_WhenComparingWithInt()
        {
            var id = new Id(1);
            id.Equals(1).Should().BeTrue();
        }

        [Fact]
        public void Equals_ShoudBeFalse_WhenComparingWithId()
        {
            var compare = new Id(2);
            var otherId = new Id(1);

            compare.Equals(otherId).Should().BeFalse();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Equals_ShouldBeFalse_WhenComparingNotIdOrInt(string input)
        {
            var compare = new Id(1);
            compare.Equals(input).Should().BeFalse();
        }

        [Theory]
        [InlineData(1, "1")]
        [InlineData(25, "25")]
        [InlineData(30, "30")]
        public void ToString_ShouldReturn_ValueAsString(int input, string expected)
        {
            var id = new Id(input);

            id.ToString().Should().Be(expected);
        }
    }
}
