using Bookstore.Domain.Entities;

using FluentAssertions;

using Xunit;

namespace Bookstore.UnitTests.Domain.Entities
{
    public class StoreTests
    {
        private const string ContractName = "Store";
        private const string InvalidIdErrorMessage = "Id must be greater or equals than zero";

        [Fact]
        public void CreateStore_ShouldBeSuccess_WithoutNotifications()
        {
            var store = new Store(0, "Test", "test@test.com");
            store.IsValid.Should().BeTrue();
            store.Notifications.Should().BeEmpty();
        }

        [Theory]
        [InlineData(-1, "Test", "test@test.com", 1)]
        [InlineData(0, "Test", "test@test", 1)]
        [InlineData(0, "T", "test@test.com", 1)]
        [InlineData(0, "T", "test@test", 2)]
        public void CreateStore_ShouldFail_WithValueObjectsNotifications(int id, string name, string email, int notificationQuantity)
        {
            var store = new Store(id, name, email);
            store.IsValid.Should().BeFalse();
            store.Notifications.Count.Should().Be(notificationQuantity);
        }

        [Fact]
        public void Equals_ShouldBeTrue_WhenComparingWithStore()
        {
            var store = new Store(0, "Test", "test@test.com");
            var otherStore = new Store(0, "Test", "test@test.com");

            store.Equals(otherStore).Should().BeTrue();
        }

        [Theory]
        [InlineData(null)]
        [InlineData(1)]
        [InlineData("")]
        public void Equals_ShouldBeFalse_WhenNotStore(object obj)
        {
            var store = new Store(0, "Test", "test@test.com");
            store.Equals(obj).Should().BeFalse();
        }
    }
}
