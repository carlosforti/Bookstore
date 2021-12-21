using Bookstore.Domain.Entities;

using FluentAssertions;

using Xunit;

namespace Bookstore.UnitTests.Domain.Entities
{
    public class BookTests
    {
        [Fact]
        public void CreateBook_ShouldBeSuccess_WithoutNotifications()
        {
            var author = new Author(0, "Test Author", "test@author.com");
            var publisher = new Publisher(0, "Test Publisher", "test@publisher.com");

            var book = new Book(0, "Test Book", author, publisher, "978-0-306-40615-7");

            book.IsValid.Should().BeTrue();
            book.Notifications.Should().BeEmpty();
        }
    }
}
