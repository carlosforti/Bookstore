using System.Collections.Generic;
using AutoMapper;
using Bookstore.Domain.Entities;
using Bookstore.Infra.Data.Dtos;
using Bookstore.Infra.Data.Interfaces;
using Bookstore.Infra.Data.Repositories;
using Bookstore.TestsCommons;
using Bookstore.TestsCommons.BogusFaker;
using FluentAssertions;
using Moq;
using Xunit;

namespace Bookstore.UnitTests.Infra.Data.Repositories;

public class BookRepositoryTests
{
    private readonly IMapper _mapper = AutoMapperHelper.Mapper;
    private readonly Mock<IBookData> _bookData = new Mock<IBookData>();
    private readonly BookRepository _bookRepository;

    public BookRepositoryTests()
    {
        _bookRepository = new BookRepository(_mapper, _bookData.Object);
    }

    [Fact]
    public async void GetAll_ShouldReturn_ListOfBooks()
    {
        var bookDtoList = BookDtoFaker.GetFakeBookDtoList();
        _bookData.Setup(data => data.GetAll())
            .ReturnsAsync(bookDtoList);

        var expectedResult = _mapper.Map<IEnumerable<Book>>(bookDtoList);

        var result = await _bookRepository.GetAll();

        result.Should().BeEquivalentTo(expectedResult);
    }

    [Fact]
    public async void GetById_ShouldReturnSingleBook_WhenFound()
    {
        var bookDto = BookDtoFaker.GetFakeBookDto();
        _bookData.Setup(x => x.GetById(It.Is<int>(id => id == bookDto.Id)))
            .ReturnsAsync(bookDto);

        var expected = _mapper.Map<Book>(bookDto);

        var result = await _bookRepository.GetById(bookDto.Id);
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async void Delete_ShouldExecute()
    {
        await _bookRepository.Delete(1);
        _bookData.Verify(data => data.Delete(It.Is<int>(id => id == 1)), Times.Once);
    }

    [Fact]
    public async void Save_ShouldExecute_AndReturnData()
    {
        var bookDto = BookDtoFaker.GetFakeBookDto();
        var book = _mapper.Map<Book>(bookDto);
        _bookData.Setup(data => data.Save(It.IsAny<BookDto>()))
            .ReturnsAsync(bookDto);

        var result = await _bookRepository.Save(book);
        result.Should().BeEquivalentTo(book);
        _bookData.Verify(data=> data.Save(It.IsAny<BookDto>()), Times.Once);
    }
    
    [Fact]
    public async void Update_ShouldExecute_AndReturnData()
    {
        var bookDto = BookDtoFaker.GetFakeBookDto();
        var book = _mapper.Map<Book>(bookDto);
        _bookData.Setup(data => data.Update(It.IsAny<BookDto>()))
            .ReturnsAsync(bookDto);

        var result = await _bookRepository.Update(book);
        result.Should().BeEquivalentTo(book);
        _bookData.Verify(data=> data.Update(It.IsAny<BookDto>()), Times.Once);
    }
}