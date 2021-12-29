using System.Collections;
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

public class AuthorRepositoryTests
{
    private readonly IMapper _mapper = AutoMapperHelper.Mapper;
    private readonly Mock<IAuthorData> _authorData = new Mock<IAuthorData>();
    private readonly AuthorRepository _authorRepository;
    
    public AuthorRepositoryTests()
    {
        _authorRepository = new AuthorRepository(_mapper, _authorData.Object);
    }

    [Fact]
    public async void GetAll_ShouldReturn_ListOfAutors()
    {
        var authorDtoList = AuthorDtoFaker.GetFakeAuthorDtoList();
        _authorData.Setup(data => data.GetAll())
            .ReturnsAsync(authorDtoList);

        var expectedResult = _mapper.Map<IEnumerable<Author>>(authorDtoList);

        var result = await _authorRepository.GetAll();
        result.Should().BeEquivalentTo(expectedResult);
    }

    [Fact]
    public async void GetById_ShouldReturnSingleAuthorDto_WhenFound()
    {
        var authorDto = AuthorDtoFaker.GetFakeAuthorDto();
        _authorData.Setup(data => data.GetById(It.Is<int>(id => id == authorDto.Id)))
            .ReturnsAsync(authorDto);

        var expectedResult = _mapper.Map<Author>(authorDto);
        var result = await _authorRepository.GetById(authorDto.Id);
        result.Should().BeEquivalentTo(expectedResult);
    }

    [Fact]
    public async void GetById_ShouldReturnNull_WhenNotFound()
    {
        _authorData.Setup(data => data.GetById(It.Is<int>(id => id == 1)))
            .ReturnsAsync(null as AuthorDto);

        var result = await _authorRepository.GetById(1);
        result.Should().BeNull();
    }

    [Fact]
    public async void Delete_ShouldExecute()
    {
        await _authorRepository.Delete(1);
        _authorData.Verify(data => data.Delete(It.Is<int>(id => id == 1)), Times.Once);
    }

    [Fact]
    public async void Save_ShouldExecute_AndReturnData()
    {
        var authorDto = AuthorDtoFaker.GetFakeAuthorDto();
        var author = _mapper.Map<Author>(authorDto);

        _authorData.Setup(data => data.Save(It.IsAny<AuthorDto>()))
            .ReturnsAsync(authorDto);

        var result = await _authorRepository.Save(author);

        result.Should().BeEquivalentTo(author);
        _authorData.Verify(data => data.Save(It.IsAny<AuthorDto>()), Times.Once);
    }
    
    [Fact]
    public async void Update_ShouldExecute_AndReturnData()
    {
        var authorDto = AuthorDtoFaker.GetFakeAuthorDto();
        var author = _mapper.Map<Author>(authorDto);

        _authorData.Setup(data => data.Update(It.IsAny<AuthorDto>()))
            .ReturnsAsync(authorDto);

        var result = await _authorRepository.Update(author);

        result.Should().BeEquivalentTo(author);
        _authorData.Verify(data => data.Update(It.IsAny<AuthorDto>()), Times.Once);
    }
}