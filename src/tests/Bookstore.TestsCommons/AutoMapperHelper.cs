using System.Diagnostics.CodeAnalysis;
using AutoMapper;

using Bookstore.Infra.Data.Profiles;

namespace Bookstore.TestsCommons
{
    [ExcludeFromCodeCoverage]
    public static class AutoMapperHelper
    {
        private static IMapper _mapper;

        public static IMapper Mapper
        {
            get
            {
                if (_mapper != null) return _mapper;
                
                var mappingConfiguration = new MapperConfiguration(option =>
                {
                    option.AddProfile<DtoToEntitiesProfile>();
                    option.AddProfile<EntitiesToDtoProfile>();
                });

                _mapper = new Mapper(mappingConfiguration);

                return _mapper;
            }
        }

    }
}
