using AutoMapper;

using Bookstore.Application.Interfaces;
using Bookstore.Domain.Entities;
using Bookstore.Infra.Data.Dtos;
using Bookstore.Infra.Data.Interfaces;

using Flunt.Notifications;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Infra.Data.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly IMapper _mapper;
        private readonly IStoreData _storeData;

        public StoreRepository(IMapper mapper, IStoreData storeData)
        {
            _mapper = mapper;
            _storeData = storeData;
        }

        public async Task Delete(int id)
        {
            await _storeData.Delete(id);
        }

        public async Task<IEnumerable<Store>> GetAll()
        {
            var stores = await _storeData.GetAll();
            return _mapper.Map<IEnumerable<Store>>(stores);
        }

        public async Task<Store> GetById(int id)
        {
            var store = await _storeData.GetById(id);

            if(store == null)
            {
                return null;
            }

            return _mapper.Map<Store>(store);
        }

        public async Task<Store> Save(Store store)
        {
            var storeDto = _mapper.Map<StoreDto>(store);
            var result = await _storeData.Save(storeDto);
            return _mapper.Map<Store>(result);
        }

        public async Task<Store> Update(Store store)
        {
            var storeDto = _mapper.Map<StoreDto>(store);
            var result = await _storeData.Update(storeDto);
            return _mapper.Map<Store>(result);
        }
    }
}
