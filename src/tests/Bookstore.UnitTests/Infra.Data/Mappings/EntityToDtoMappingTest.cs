
using Bookstore.Domain.Entities;
using Bookstore.Infra.Data.Dtos;
using Bookstore.TestsCommons;

using FluentAssertions;

using Xunit;

namespace Bookstore.UnitTests.Infra.Data.Mappings
{
    public class EntityToDtoMappingTest
    {
        private static Store GetStore() => new(1, "Store", "test@store.com");
        private static Author GetAuthor() => new(1, "Author", "test@author.com");
        private static Publisher GetPublisher() => new(1, "Publisher", "test@publisher.com");
        private static Book GetBook() => new(1, "Book", GetAuthor(), GetPublisher(), "9789873303111");

        private static StoreDto GetStoreDto() => new() { Id = 1, Name = "Store", Email = "test@store.com" };
        private static AuthorDto GetAuthorDto() => new() { Id = 1, Name = "Author", Email = "test@author.com" };
        private static PublisherDto GetPublisherDto() => new() { Id = 1, Name = "Publisher", Email = "test@publisher.com" };
        private static BookDto GetBookDto() => new()
        {
            Id = 1, Name = "Book", Author = GetAuthorDto(), Publisher = GetPublisherDto(), Isbn = "9789873303111",
            AuthorId = 1, PublisherId = 1
        };

        [Fact]
        public void MapStoreToDto_ShouldBeSuccess()
        {
            var store = GetStore();
            var storeDto = GetStoreDto();

            var result = AutoMapperHelper.Mapper.Map<StoreDto>(store);
            result.Should().BeEquivalentTo(storeDto);
        }

        [Fact]
        public void MapStoreDtoToEntity_ShouldBeSuccess()
        {
            var store = GetStore();
            var storeDto = GetStoreDto();

            var result = AutoMapperHelper.Mapper.Map<Store>(storeDto);
            result.Should().BeEquivalentTo(store);
        }

        [Fact]
        public void MapAuthorToDto_ShouldBeSuccess()
        {
            var author = GetAuthor();
            var authorDto = GetAuthorDto();

            var result = AutoMapperHelper.Mapper.Map<AuthorDto>(author);
            result.Should().BeEquivalentTo(authorDto);
        }

        [Fact]
        public void MapAuthorDtoToEntity_ShouldBeSuccess()
        {
            var author = GetAuthor();
            var authorDto = GetAuthorDto();

            var result = AutoMapperHelper.Mapper.Map<Author>(authorDto);
            result.Should().BeEquivalentTo(author);
        }

        [Fact]
        public void MapPublisherToDto_ShouldBeSucces()
        {
            var publisher = GetPublisher();
            var publisherDto = GetPublisherDto();

            var result = AutoMapperHelper.Mapper.Map<PublisherDto>(publisher);
            result.Should().BeEquivalentTo(publisherDto);
        }

        [Fact]
        public void MapPublisherDtoToEntity_ShouldBeSucces()
        {
            var publisher = GetPublisher();
            var publisherDto = GetPublisherDto();

            var result = AutoMapperHelper.Mapper.Map<Publisher>(publisherDto);
            result.Should().BeEquivalentTo(publisher);
        }

        [Fact]
        public void MapBookToDto_ShouldBeSuccess()
        {
            var book = GetBook();
            var bookDto = GetBookDto();

            var result = AutoMapperHelper.Mapper.Map<BookDto>(book);
            result.Should().BeEquivalentTo(bookDto);
        }
    }
}
