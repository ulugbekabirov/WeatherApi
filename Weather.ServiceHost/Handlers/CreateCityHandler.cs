using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Weather.RA.SqlRepositories;
using Weather.ServiceHost.Commands;

namespace Weather.ServiceHost.Handlers
{
    public class CreateCityHandler : AsyncRequestHandler<CreateCityCommand>
    {
        private readonly CityRepository _cityRepository;

        protected override async Task Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            await _cityRepository.CreateAsync(request.City);
        }
    }
}
