using AutoMapper;
using Weather.Data.Entities;
using Weather.SDK.DTO;

namespace Weather.ServiceHost.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<City, CityDTO>().ReverseMap();

            CreateMap<Country, CountryDTO>().ReverseMap();
        }
    }
}
