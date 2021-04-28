using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Weather.Data.Entities;
using Weather.RA.SqlRepositories;
using Weather.SDK.DTO;

namespace Weather.ServiceHost.Handlers.CountryHandlers
{
    public class CreateCountryRequest : IRequest
    {
        public CountryDTO Country { get; set; }
    }

    public class CreateCountryHandler : AsyncRequestHandler<CreateCountryRequest>
    {
        private readonly CountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CreateCountryHandler(CountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        protected override async Task Handle(CreateCountryRequest request, CancellationToken cancellationToken)
        {
            var country = _mapper.Map<Country>(request.Country);
            await _countryRepository.CreateAsync(country);
        }
    }
}
