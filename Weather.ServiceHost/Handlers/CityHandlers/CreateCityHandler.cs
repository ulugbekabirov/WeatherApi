using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Weather.Data.Entities;
using Weather.RA.SqlRepositories;
using Weather.ServiceHost.Commands.CityCommands;

namespace Weather.ServiceHost.Handlers.CityHandlers
{
    public class CreateCityHandler : AsyncRequestHandler<CreateCityCommand>
    {
        private readonly CityRepository _cityRepository;
        private readonly IMapper _mapper;

        public CreateCityHandler(CityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        protected override async Task Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            var city = _mapper.Map<City>(request.City);
            await _cityRepository.CreateAsync(city);
        }
    }
}
