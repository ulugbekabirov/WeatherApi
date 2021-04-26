using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Weather.RA.SqlRepositories;
using Weather.SDK.DTO;
using Weather.ServiceHost.Commands.CityCommands;

namespace Weather.ServiceHost.Handlers
{
    public class GetCityHandler : IRequestHandler<GetCityCommand, CityDTO>
    {
        private readonly CityRepository _cityRepository;
        private readonly IMapper _mapper;

        public GetCityHandler(CityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<CityDTO> Handle(GetCityCommand request, CancellationToken cancellationToken)
        {
            var city = await _cityRepository.GetByIdAsync(request.CityId);
            return _mapper.Map<CityDTO>(city);
        }
    }
}
