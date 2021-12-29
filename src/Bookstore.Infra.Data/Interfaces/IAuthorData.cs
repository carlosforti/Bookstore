using Bookstore.Infra.Data.Dtos;
using Bookstore.Infra.Data.Interfaces;

namespace Bookstore.Infra.Postgresql.Interfaces
{
    public interface IAuthorData : IBaseData<AuthorDto>
    {
    }
}
