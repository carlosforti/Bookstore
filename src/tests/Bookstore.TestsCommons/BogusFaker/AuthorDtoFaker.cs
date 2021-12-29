using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Bogus;
using Bookstore.Infra.Data.Dtos;

namespace Bookstore.TestsCommons.BogusFaker
{
    [ExcludeFromCodeCoverage]
    public static class AuthorDtoFaker
    {
        private static Faker<AuthorDto> GetFakeAuthorDtoInternal(int? id = null) =>
            new Faker<AuthorDto>()
                .CustomInstantiator(faker =>
                    new AuthorDto
                    {
                        Id = id ?? (int)faker.Random.UInt(),
                        Name = faker.Person.FullName,
                        Email = faker.Person.Email
                    });

        public static AuthorDto GetFakeAuthorDto(int? id = null) =>
            GetFakeAuthorDtoInternal(id).Generate();

        public static IEnumerable<AuthorDto> GetFakeAuthorDtoList(int capacity = 3) =>
            GetFakeAuthorDtoInternal().Generate(capacity);
    }
}