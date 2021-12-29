using AutoMapper;

using Bookstore.Domain.Entities;
using Bookstore.Infra.Data.Dtos;

namespace Bookstore.Infra.Data.Mappings
{
    public class DtoToEntitiesProfile : Profile
    {
        public DtoToEntitiesProfile()
        {
            CreateMap<StoreDto, Store>();
            CreateMap<AuthorDto, Author>();
            CreateMap<BookDto, Book>();
            CreateMap<PublisherDto, Publisher>();
        }
    }
}
