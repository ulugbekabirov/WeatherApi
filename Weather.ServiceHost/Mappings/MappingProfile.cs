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

            CreateMap<CreateCityDTO, City>().ReverseMap();

            CreateMap<CreateCountryDTO, Country>().ReverseMap();

            CreateMap<UpdateCityDTO, City>().ReverseMap();

            CreateMap<UpdateCountryDTO, Country>().ReverseMap();
        }
    }
}
