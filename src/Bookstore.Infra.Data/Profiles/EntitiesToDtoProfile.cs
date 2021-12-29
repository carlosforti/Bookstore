using AutoMapper;

using Bookstore.Domain.Entities;
using Bookstore.Infra.Data.Dtos;

namespace Bookstore.Infra.Data.Profiles
{
    public class EntitiesToDtoProfile : Profile
    {
        public EntitiesToDtoProfile()
        {
            CreateMap<Author, AuthorDto>();
            CreateMap<Publisher, PublisherDto>();
            CreateMap<Book, BookDto>();
            CreateMap<Store, StoreDto>();
        }
    }
}
