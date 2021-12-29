using AutoMapper;

using Bookstore.Application.Interfaces;
using Bookstore.Domain.Entities;
using Bookstore.Infra.Data.Dtos;
using Bookstore.Infra.Data.Interfaces;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookstore.Infra.Data.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly IMapper _mapper;
        private readonly IPublisherData _publisherData;

        public PublisherRepository(IMapper mapper, IPublisherData publisherData)
        {
            _mapper = mapper;
            _publisherData = publisherData;
        }

        public async Task Delete(int id)
        {
            await _publisherData.Delete(id);
        }

        public async Task<IEnumerable<Publisher>> GetAll()
        {
            var result = await _publisherData.GetAll();
            return _mapper.Map<IEnumerable<Publisher>>(result);
        }

        public async Task<Publisher> GetById(int id)
        {
            var publisherDto = await _publisherData.GetById(id);
            return _mapper.Map<Publisher>(publisherDto);
        }

        public async Task<Publisher> Save(Publisher publisher)
        {
            var publisherDto = _mapper.Map<PublisherDto>(publisher);
            var result = await _publisherData.Save(publisherDto);
            return _mapper.Map<Publisher>(result);
        }

        public async Task<Publisher> Update(Publisher publisher)
        {
            var publisherDto = _mapper.Map<PublisherDto>(publisher);
            var result = await _publisherData.Update(publisherDto);
            return _mapper.Map<Publisher>(result);
        }
    }
}
