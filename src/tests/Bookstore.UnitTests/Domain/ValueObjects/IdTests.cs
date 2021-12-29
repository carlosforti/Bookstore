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
    }
}
