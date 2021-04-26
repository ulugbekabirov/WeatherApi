using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Weather.Data.Entities;
using Weather.RA.SqlRepositories;
using Weather.ServiceHost.Commands.CountryCommands;

namespace Weather.ServiceHost.Handlers
{
    public class CreateCountryHandler : AsyncRequestHandler<CreateCountryCommand>
    {
        private readonly CountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CreateCountryHandler(CountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        protected override async Task Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            var country = _mapper.Map<Country>(request.Country);
            await _countryRepository.CreateAsync(country);
        }
    }
}
