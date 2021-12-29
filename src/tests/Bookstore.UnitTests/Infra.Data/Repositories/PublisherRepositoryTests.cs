using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
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

public class PublisherRepositoryTests
{
    private readonly IMapper _mapper = AutoMapperHelper.Mapper;
    private readonly Mock<IPublisherData> _publisherData = new Mock<IPublisherData>();
    private readonly PublisherRepository _publisherRepository;

    public PublisherRepositoryTests()
    {
        _publisherRepository = new PublisherRepository(_mapper, _publisherData.Object);
    }

    [Fact]
    public async void GetAll_ShouldReturn_ListOfPublishers()
    {
        var publisherDtoList = PublisherDtoFaker.GetFakePublisherDtoList();
        _publisherData.Setup(data => data.GetAll())
            .ReturnsAsync(publisherDtoList);

        var expectedResult = _mapper.Map<IEnumerable<Publisher>>(publisherDtoList);

        var result = await _publisherRepository.GetAll();

        result.Should().BeEquivalentTo(expectedResult);
    }

    [Fact]
    public async void GetById_ShouldReturnSinglePublisher_WhenFound()
    {
        var publisherDto = PublisherDtoFaker.GetFakePublisherDto();
        _publisherData.Setup(data => data.GetById(It.Is<int>(id => id == publisherDto.Id)))
            .ReturnsAsync(publisherDto);

        var expectedResult = _mapper.Map<Publisher>(publisherDto);

        var result = await _publisherRepository.GetById(publisherDto.Id);
        result.Should().BeEquivalentTo(expectedResult);
    }
    
    [Fact]
    public async void GetById_ShouldReturnNull_WhenNotFound()
    {
        _publisherData.Setup(data => data.GetById(It.Is<int>(id => id == 0)))
            .ReturnsAsync(null as PublisherDto);

        var result = await _publisherRepository.GetById(1);
        result.Should().BeNull();
    }

    [Fact]
    public async void Delete_ShouldExecute()
    {
        await _publisherRepository.Delete(1);
        _publisherData.Verify(data => data.Delete(It.Is<int>(id => id == 1)), Times.Once);
    }

    [Fact]
    public async void Save_ShouldExecute_AndReturnData()
    {
        var publisherDto = PublisherDtoFaker.GetFakePublisherDto();
        var publisher = _mapper.Map<Publisher>(publisherDto);
        _publisherData.Setup(data => data.Update(It.IsAny<PublisherDto>()))
            .ReturnsAsync(publisherDto);

        var result = await _publisherRepository.Save(publisher);
        _publisherData.Verify(data => data.Save(It.IsAny<PublisherDto>()), Times.Once);
    }
    
    [Fact]
    public async void Update_ShouldExecute_AndReturnData()
    {
        var publisherDto = PublisherDtoFaker.GetFakePublisherDto();
        var publisher = _mapper.Map<Publisher>(publisherDto);
        _publisherData.Setup(data => data.Update(It.IsAny<PublisherDto>()))
            .ReturnsAsync(publisherDto);

        var result = await _publisherRepository.Update(publisher);
        _publisherData.Verify(data => data.Update(It.IsAny<PublisherDto>()), Times.Once);
    }
}