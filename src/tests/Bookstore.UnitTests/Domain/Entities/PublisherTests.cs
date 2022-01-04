using Bookstore.Domain.Entities;

using FluentAssertions;

using Xunit;

namespace Bookstore.UnitTests.Domain.Entities
{
    public class PublisherTests
    {
        [Fact]
        public void CreatePublisher_ShouldBeSuccess_WithoutNotifications()
        {
            var publisher = new Publisher(0, "Test", "test@test.com");
            publisher.IsValid.Should().BeTrue();
            publisher.Notifications.Should().BeEmpty();
        }

        [Theory]
        [InlineData(-1, "Test", "test@test.com", 1)]
        [InlineData(0, "Test", "test@test", 1)]
        [InlineData(0, "T", "test@test.com", 1)]
        [InlineData(0, "T", "test@test", 2)]
        public void CreatePublisher_ShouldFail_WithValueObjectsNotifications(int id, string name, string email, int notificationQuantity)
        {
            var publisher = new Publisher(id, name, email);
            publisher.IsValid.Should().BeFalse();
            publisher.Notifications.Count.Should().Be(notificationQuantity);
        }

        [Fact]
        public void Equals_ShouldBeTrue_WhenComparingPublisher()
        {
            var publisher = new Publisher(0, "Test", "test@test.com");
            var otherPublisher = new Publisher(0, "Test", "test@test.com");

            publisher.Equals(otherPublisher).Should().BeTrue();
        }

        [Theory]
        [InlineData(null)]
        [InlineData(1)]
        [InlineData("")]
        public void Equals_ShouldBeFalse_WhenComparingOthers(object obj)
        {
            var publisher = new Publisher(0, "Test", "test@test.com");
            publisher.Equals(obj).Should().BeFalse();
        }
    }
}