using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Bogus;
using Bookstore.Infra.Data.Dtos;
using Bookstore.TestsCommons.BogusFaker.ExtensionMethods;

namespace Bookstore.TestsCommons.BogusFaker
{
    [ExcludeFromCodeCoverage]
    public static class BookDtoFaker
    {
        private static Faker<BookDto> GetFakeBookDtoInternal(int? id = null)
        {
            return new Faker<BookDto>()
                .CustomInstantiator(faker =>
                {
                    var authorDto = AuthorDtoFaker.GetFakeAuthorDto();
                    var publisherDto = PublisherDtoFaker.GetFakePublisherDto();

                    return new BookDto
                    {
                        Id = id ?? (int)faker.Random.UInt(),
                        Name = faker.Random.String2(100),
                        Author = authorDto,
                        Publisher = publisherDto,
                        Isbn = faker.Random.Isbn(),
                        AuthorId = authorDto.Id,
                        PublisherId = publisherDto.Id
                    };
                });
        }

        public static BookDto GetFakeBookDto(int? id = null) =>
            GetFakeBookDtoInternal(id).Generate();

        public static IEnumerable<BookDto> GetFakeBookDtoList(int quantity = 3) =>
            GetFakeBookDtoInternal().Generate(3);
    }
}