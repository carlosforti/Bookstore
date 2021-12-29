using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Bogus;
using Bogus.Extensions.Brazil;
using Bookstore.Infra.Data.Dtos;

namespace Bookstore.TestsCommons.BogusFaker
{
    [ExcludeFromCodeCoverage]
    public static class PublisherDtoFaker
    {
        private static Faker<PublisherDto> GetFakePublishDtoInternal(int? id = null) =>
            new Faker<PublisherDto>()
                .CustomInstantiator(faker =>
                    new PublisherDto
                    {
                        Id = id ?? (int)faker.Random.UInt(),
                        Name = faker.Company.CompanyName(),
                        Email = faker.Internet.Email()
                    });

        public static PublisherDto GetFakePublisherDto(int? id = null) =>
            GetFakePublishDtoInternal(id).Generate();

        public static IEnumerable<PublisherDto> GetFakePublisherDtoList(int quantity = 3) =>
            GetFakePublishDtoInternal().Generate(quantity);
    }
}