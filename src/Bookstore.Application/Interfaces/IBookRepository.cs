using Bookstore.Domain.Entities;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookstore.Application.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAll();
        Task<Book> GetById(int id);
        Task<Book> Save(Book book);
        Task<Book> Update(Book book);
        Task Delete(int id);
    }
}
