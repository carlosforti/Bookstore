﻿using AutoMapper;

using Bookstore.Application.Interfaces;
using Bookstore.Domain.Entities;
using Bookstore.Infra.Data.Dtos;
using Bookstore.Infra.Data.Interfaces;
using Bookstore.Infra.Data.Repositories;
using Bookstore.TestsCommons;
using Bookstore.TestsCommons.BogusFaker;

using FluentAssertions;

using Moq;

using System.Collections.Generic;

using Xunit;

namespace Bookstore.UnitTests.Infra.Data.Repositories
{
    public class StoreRepositoryTests
    {
        private readonly IMapper _mapper = AutoMapperHelper.Mapper;
        private readonly Mock<IStoreData> _storeData = new Mock<IStoreData>();
        private readonly StoreRepository _storeRepository;

        public StoreRepositoryTests()
        {
            _storeRepository = new StoreRepository(_mapper, _storeData.Object);
        }

        [Fact]
        public async void GetAll_ShouldReturn_ListOfStores()
        {
            var stores = StoreDtoFaker.GetFakeStoreDtoList();
            _storeData
                .Setup(s => s.GetAll())
                .ReturnsAsync(stores);

            var expectedResult = _mapper.Map<IEnumerable<Store>>(stores);

            var result = await _storeRepository.GetAll();
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public async void GetById_ShouldReturnSingleStore_WhenFound()
        {
            var store = StoreDtoFaker.GetFakeStoreDto();
            _storeData
                .Setup(s => s.GetById(It.Is<int>(id => id == store.Id)))
                .ReturnsAsync(store);

            var expectedResult = _mapper.Map<Store>(store);

            var result = await _storeRepository.GetById(store.Id);
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public async void GetById_ShouldReturnNull_WhenNotFound()
        {
            var store = StoreDtoFaker.GetFakeStoreDto();
            _storeData
                .Setup(s => s.GetById(It.Is<int>(id => id == store.Id)))
                .ReturnsAsync(store);

            var expectedResult = _mapper.Map<Store>(store);

            var result = await _storeRepository.GetById(store.Id + 1);
            result.Should().BeNull();
        }

        [Fact]
        public async void Delete_ShouldExecute()
        {
            await _storeRepository.Delete(1);
            _storeData.Verify(x => x.Delete(It.Is<int>(n => n == 1)), Times.Once());
        }

        [Fact]
        public async void Save_ShouldExecute_AndReturnData()
        {
            var storeDto = StoreDtoFaker.GetFakeStoreDto();
            var store = _mapper.Map<Store>(storeDto);

            _storeData
                .Setup(x => x.Save(It.IsAny<StoreDto>()))
                .ReturnsAsync(storeDto);

            var result = await _storeRepository.Save(store);
            result.Should().BeEquivalentTo(store);
            _storeData.Verify(x => x.Save(It.IsAny<StoreDto>()), Times.Once());
        }

        [Fact]
        public async void Update_ShouldExecute_AndReturnData()
        {
            var storeDto = StoreDtoFaker.GetFakeStoreDto();
            var store = _mapper.Map<Store>(storeDto);

            _storeData
                .Setup(x => x.Update(It.IsAny<StoreDto>()))
                .ReturnsAsync(storeDto);

            var result = await _storeRepository.Update(store);
            result.Should().BeEquivalentTo(store);
            _storeData.Verify(x => x.Update(It.IsAny<StoreDto>()), Times.Once());
        }
    }
}
