using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Weather.RA.Interfaces;
using Weather.SDK.DTO;

namespace Weather.ServiceHost.Handlers.CityHandlers
{
    public class GetCityRequest : IRequest<CityDTO>
    {
        public int CityId { get; set; }
    }

    public class GetCityHandler : IRequestHandler<GetCityRequest, CityDTO>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public GetCityHandler(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<CityDTO> Handle(GetCityRequest request, CancellationToken cancellationToken)
        {
            var city = await _cityRepository.GetByIdAsync(request.CityId);
            return _mapper.Map<CityDTO>(city);
        }
    }
}
