using Bookstore.Infra.Data.Dtos;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookstore.Infra.Data.Interfaces
{
    public interface IBaseData<TDto>
        where TDto : BaseDto
    {
        Task Delete(int id);
        Task<IEnumerable<TDto>> GetAll();
        Task<TDto> GetById(int id);
        Task<TDto> Save(TDto dto);
        Task<TDto> Update(TDto dto);
    }
}