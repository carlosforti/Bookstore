using AutoMapper;

using Bookstore.Application.Interfaces;
using Bookstore.Domain.Entities;
using Bookstore.Infra.Data.Dtos;
using Bookstore.Infra.Data.Interfaces;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookstore.Infra.Data.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly IMapper _mapper;
        private readonly IAuthorData _authorData;

        public AuthorRepository(IMapper mapper, IAuthorData authorData)
        {
            _mapper = mapper;
            _authorData = authorData;
        }

        public async Task Delete(int id)
        {
            await _authorData.Delete(id);
        }

        public async Task<IEnumerable<Author>> GetAll()
        {
            var result = await _authorData.GetAll();
            return _mapper.Map<IEnumerable<Author>>(result);
        }

        public async Task<Author> GetById(int id)
        {
            var authorDto = await _authorData.GetById(id);
            return _mapper.Map<Author>(authorDto);
        }

        public async Task<Author> Save(Author author)
        {
            var authorDto = _mapper.Map<AuthorDto>(author);
            var result = await _authorData.Save(authorDto);
            return _mapper.Map<Author>(result);
        }

        public async Task<Author> Update(Author author)
        {
            var authorDto = _mapper.Map<AuthorDto>(author);
            var result = await _authorData.Update(authorDto);
            return _mapper.Map<Author>(result);
        }
    }
}
