using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Weather.Data.Entities;
using Weather.RA.SqlRepositories;
using Weather.ServiceHost.Commands;

namespace Weather.ServiceHost.Handlers
{
    public class CreateCountryHandler : AsyncRequestHandler<CreateCountryCommand>
    {
        private readonly CountryRepository _countryRepository;

        public CreateCountryHandler(CountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        protected override async Task Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            await _countryRepository.CreateAsync(request.Country);
        }
    }
}
