using AutoMapper;

using Bookstore.Application.Interfaces;
using Bookstore.Domain.Entities;
using Bookstore.Infra.Data.Dtos;
using Bookstore.Infra.Data.Interfaces;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookstore.Infra.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IMapper _mapper;
        private readonly IBookData _bookData;

        public BookRepository(IMapper mapper, IBookData bookData)
        {
            _mapper = mapper;
            _bookData = bookData;
        }

        public async Task Delete(int id)
        {
            await _bookData.Delete(id);
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            var result = await _bookData.GetAll();
            return _mapper.Map<IEnumerable<Book>>(result);
        }

        public async Task<Book> GetById(int id)
        {
            var bookDto = await _bookData.GetById(id);
            return _mapper.Map<Book>(bookDto);
        }

        public async Task<Book> Save(Book book)
        {
            var bookDto = _mapper.Map<BookDto>(book);
            var result = await _bookData.Save(bookDto);
            return _mapper.Map<Book>(result);
        }

        public async Task<Book> Update(Book book)
        {
            var bookDto = _mapper.Map<BookDto>(book);
            var result = await _bookData.Update(bookDto);
            return _mapper.Map<Book>(result);
        }
    }
}
