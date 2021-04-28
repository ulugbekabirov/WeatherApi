using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Weather.Data.Entities;
using Weather.RA.SqlRepositories;
using Weather.SDK.DTO;

namespace Weather.ServiceHost.Handlers.CityHandlers
{
    public class CreateCityRequest : IRequest
    {
        public CityDTO City { get; set; }
    }

    public class CreateCityHandler : AsyncRequestHandler<CreateCityRequest>
    {
        private readonly CityRepository _cityRepository;
        private readonly IMapper _mapper;

        public CreateCityHandler(CityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        protected override async Task Handle(CreateCityRequest request, CancellationToken cancellationToken)
        {
            var city = _mapper.Map<City>(request.City);
            await _cityRepository.CreateAsync(city);
        }
    }
}
