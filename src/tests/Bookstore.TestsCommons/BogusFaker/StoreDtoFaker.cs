using Bogus;
using Bookstore.Infra.Data.Dtos;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Bookstore.TestsCommons.BogusFaker
{
    [ExcludeFromCodeCoverage]
    public static class StoreDtoFaker
    {
        private static Faker<StoreDto> GetFakeStoreInternal(int? id = null) =>
            new Faker<StoreDto>()
                .CustomInstantiator(faker =>
                    new StoreDto
                    {
                        Id = id ?? (int)faker.Random.UInt(),
                        Name = faker.Person.FullName,
                        Email = faker.Person.Email
                    });

        public static StoreDto GetFakeStoreDto(int? id = null) => 
            GetFakeStoreInternal(id).Generate();

        public static IEnumerable<StoreDto> GetFakeStoreDtoList(int quantity = 3) =>
            GetFakeStoreInternal().Generate(quantity);
    }
}