using Bookstore.Domain.Entities;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookstore.Application.Interfaces
{
    public interface IStoreRepository
    {
        Task<IEnumerable<Store>> GetAll();
        Task<Store> GetById(int id);
        Task<Store> Save(Store store);
        Task<Store> Update(Store store);
        Task Delete(int id);
    }
}
