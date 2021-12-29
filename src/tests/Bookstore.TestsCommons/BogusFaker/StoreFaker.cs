using Bogus;

using Bookstore.Domain.Entities;

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Bookstore.TestsCommons.BogusFaker
{
    [ExcludeFromCodeCoverage]
    public static class StoreFaker
    {
        public static Store GetFakerStore() =>
            new Faker<Store>()
                .CustomInstantiator(faker =>
                {
                    return new Store(faker.Random.Int(), faker.Person.FullName, faker.Person.Email);
                });

        public static IEnumerable<Store> GetFakerStores(int quantity = 3)
        {
            var stores = new List<Store>();
            
            for(var i = 0; i < quantity; i++)
            {
                stores.Add(GetFakerStore());
            }

            return stores;
        }
    }
}
