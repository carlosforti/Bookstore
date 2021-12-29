using AutoMapper;

using Bookstore.Infra.Data.Mappings;

namespace Bookstore.TestsCommons
{
    public static class AutoMapperHelper
    {
        private static IMapper _mapper;

        public static IMapper Mapper
        {
            get
            {
                if (_mapper == null)
                {
                    var mappingConfiguration = new MapperConfiguration(option =>
                    {
                        option.AddProfile<DtoToEntitiesProfile>();
                        option.AddProfile<EntitiesToDtoProfile>();
                    });

                    _mapper = new Mapper(mappingConfiguration);
                }

                return _mapper;
            }
        }

    }
}
