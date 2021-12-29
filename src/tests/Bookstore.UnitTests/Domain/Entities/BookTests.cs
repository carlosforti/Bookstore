using Bookstore.Domain.Entities;

using FluentAssertions;

using Xunit;

namespace Bookstore.UnitTests.Domain.Entities
{
    public class BookTests
    {
        private static Author GetAuthor() => new(0, "Test Author", "test@author.com");
        private static Publisher GetPublisher() => new(0, "Test Publisher", "test@publisher.com");

        [Fact]
        public void CreateBook_ShouldBeSuccess_WithoutNotifications()
        {
            var author = GetAuthor();
            var publisher = GetPublisher();

            var book = new Book(0, "Test Book", author, publisher, "978-0-306-40615-7");

            book.IsValid.Should().BeTrue();
            book.Notifications.Should().BeEmpty();
        }

        [Theory]
        [InlineData(-1, "Test Book", "978-0-306-40615-7")]
        [InlineData(0, "T", "978-0-306-40615-7")]
        [InlineData(0, "Test Book", "978-0-306-40615-8")]
        public void CreateBook_ShouldFail_WithNotifications(int id, string name, string isbn)
        {
            var author = GetAuthor();
            var publisher = GetPublisher();

            var book = new Book(id, name, author, publisher, isbn);

            book.IsValid.Should().BeFalse();
            book.Notifications.Should().NotBeEmpty();
        }

        [Fact]
        public void Equals_ShouldBeTrue()
        {
            var book = new Book(1, "Test Book", GetAuthor(), GetPublisher(), "978-0-306-40615-7");
            var book2 = new Book(1, "Test Book", GetAuthor(), GetPublisher(), "978-0-306-40615-7");
        
            book.Equals(book2).Should().BeTrue();
        }

        [Fact]
        public void Equals_ShouldBeFalse_WhenDifferentBooks()
        {
            var book = new Book(1, "Test Book", GetAuthor(), GetPublisher(), "978-0-306-40615-7");
            var book2 = new Book(2, "Test Book", GetAuthor(), GetPublisher(), "978-0-306-40615-7");

            book.Equals(book2).Should().BeFalse();
        }

        [Fact]
        public void Equals_ShouldBeFalse_WhenNull()
        {
            var book = new Book(1, "Test Book", GetAuthor(), GetPublisher(), "978-0-306-40615-7");

            book.Equals(null).Should().BeFalse();
        }
    }
}
