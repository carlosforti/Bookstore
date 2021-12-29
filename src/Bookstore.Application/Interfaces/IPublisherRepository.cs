using Bookstore.Domain.Entities;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookstore.Application.Interfaces
{
    public interface IPublisherRepository
    {
        Task<IEnumerable<Publisher>> GetAll();
        Task<Publisher> GetById(int id);
        Task<Publisher> Save(Publisher publisher);
        Task<Publisher> Update(Publisher publisher);
        Task Delete(int id);
    }
}
