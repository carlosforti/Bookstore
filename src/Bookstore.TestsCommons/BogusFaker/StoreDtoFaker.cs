using Bogus;

using Bookstore.Infra.Data.Dtos;

using System;
using System.Collections.Generic;
using System.Text;

namespace Bookstore.TestsCommons.BogusFaker
{
    public static class StoreDtoFaker
    {
        public static StoreDto GetFakerStoreDto() =>
            new Faker<StoreDto>()
                .CustomInstantiator(faker =>
                {
                    return new StoreDto
                    {
                        Id = faker.Random.Int(),
                        Name = faker.Person.FullName,
                        Email = faker.Person.Email
                    };
                });

        public static IEnumerable<StoreDto> GetFakerStoresDtos(int quantity = 3)
        {
            var stores = new List<StoreDto>();

            for (var i = 0; i < quantity; i++)
            {
                stores.Add(GetFakerStoreDto());
            }

            return stores;
        }
    }
}
