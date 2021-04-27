using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Weather.RA.SqlRepositories;
using Weather.SDK.DTO;

namespace Weather.ServiceHost.Handlers.CityHandlers
{
    public class GetAllCitiesRequest : IRequest<IEnumerable<CityDTO>>
    {

    }
    public class GetAllCitiesHandler : IRequestHandler<GetAllCitiesRequest, IEnumerable<CityDTO>>
    {
        private readonly CityRepository _cityRepository;
        private readonly IMapper _mapper;

        public GetAllCitiesHandler(CityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CityDTO>> Handle(GetAllCitiesRequest request, CancellationToken cancellationToken)
        {
            var cities = await _cityRepository.GetAllAsync();
            return _mapper.Map<CityDTO[]>(cities);
        }
    }
}
