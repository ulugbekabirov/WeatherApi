using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Weather.Data.Entities;
using Weather.RA.Interfaces;
using Weather.SDK.DTO;

namespace Weather.ServiceHost.Handlers.CityHandlers
{
    public class UpdateCityRequest : IRequest
    {
        public CityDTO City { get; set; }
    }

    public class UpdateCityHandler : AsyncRequestHandler<UpdateCityRequest>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public UpdateCityHandler(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        protected override async Task Handle(UpdateCityRequest request, CancellationToken cancellationToken)
        {
            var city = _mapper.Map<City>(request.City);
            await _cityRepository.UpdateAsync(city);
        }
    }
}
