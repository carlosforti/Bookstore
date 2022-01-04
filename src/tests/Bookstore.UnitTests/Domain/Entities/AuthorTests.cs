using Bookstore.Domain.Entities;

using FluentAssertions;

using Flunt.Notifications;

using Xunit;

namespace Bookstore.UnitTests.Domain.Entities
{
    public class AuthorTests
    {
        [Fact]
        public void CreateAuthor_ShouldBeSuccess_WithoutNotifications()
        {
            var author = new Author(0, "Test", "test@test.com");
            author.IsValid.Should().BeTrue();
            author.Notifications.Should().BeEmpty();
        }

        [Theory]
        [InlineData(-1, "Test", "test@test.com", 1, "Author.Id", "Id must be greater or equals than zero")]
        [InlineData(0, "Test", "test@test", 1, "Author.Email", "Invalid e-mail address")]
        [InlineData(0, "T", "test@test.com", 1, "Author.Name", "Name must be 3 to 300 characters long")]
        [InlineData(0, "T", "test@test", 2, "Author.Name", "Name must be 3 to 300 characters long")]
        public void CreateAuthor_ShouldFail_WithValueObjectsNotifications(int id, string name, string email, int notificationQuantity, string expectedKey, string expectedMessage)
        {
            var expectedNotification = new Notification(expectedKey, expectedMessage);

            var author = new Author(id, name, email);
            author.IsValid.Should().BeFalse();
            author.Notifications.Count.Should().Be(notificationQuantity);
            author.Notifications.Should().ContainEquivalentOf(expectedNotification);
        }

        [Fact]
        public void Equals_ShouldBeTrue()
        {
            var author = new Author(1, "Test", "test@test.com");
            var author2 = new Author(1, "Test", "test@test.com");

            author.Equals(author2).Should().BeTrue();
        }

        [Fact]
        public void Equals_ShouldBeFalse_WhenDifferentAuthor()
        {
            var author = new Author(1, "Test", "test@test.com");
            var author2 = new Author(2, "Test", "test@test.com");

            author.Equals(author2).Should().BeFalse();
        }

        [Fact]
        public void Equals_ShouldBeFalse_WhenNull()
        {
            var author = new Author(1, "Test", "test@test.com");

            author.Equals(null).Should().BeFalse();
        }
    }
}