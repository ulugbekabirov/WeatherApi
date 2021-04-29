using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Weather.RA.Interfaces;

namespace Weather.ServiceHost.Handlers.CityHandlers
{
    public class DeleteCityRequest : IRequest
    {
        public int CityId { get; set; }
    }

    public class DeleteCityHandler : AsyncRequestHandler<DeleteCityRequest>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public DeleteCityHandler(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        protected override async Task Handle(DeleteCityRequest request, CancellationToken cancellationToken)
        {
            await _cityRepository.DeleteSoftlyAsync(request.CityId);
        }
    }
}
