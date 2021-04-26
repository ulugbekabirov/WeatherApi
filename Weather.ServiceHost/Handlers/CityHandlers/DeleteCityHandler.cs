using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Weather.RA.SqlRepositories;
using Weather.ServiceHost.Commands.CityCommands;

namespace Weather.ServiceHost.Handlers.CityHandlers
{
    public class DeleteCityHandler : AsyncRequestHandler<DeleteCityCommand>
    {
        private readonly CityRepository _cityRepository;
        private readonly IMapper _mapper;

        public DeleteCityHandler(CityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        protected override async Task Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            await _cityRepository.DeleteSoftlyAsync(request.CityId);
        }
    }
}
