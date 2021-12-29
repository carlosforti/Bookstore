using Bookstore.Domain.Entities;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookstore.Application.Interfaces
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAll();
        Task<Author> GetById(int id);
        Task<Author> Save(Author author);
        Task<Author> Update(Author author);
        Task Delete(int id);
    }
}
