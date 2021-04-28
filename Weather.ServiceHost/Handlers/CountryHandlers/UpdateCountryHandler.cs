using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Weather.Data.Entities;
using Weather.RA.SqlRepositories;
using Weather.SDK.DTO;

namespace Weather.ServiceHost.Handlers.CountryHandlers
{
    public class UpdateCountryRequest : IRequest
    {
        public CountryDTO Country { get; set; }
    }

    public class UpdateCountryHandler : AsyncRequestHandler<UpdateCountryRequest>
    {
        private readonly CountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public UpdateCountryHandler(CountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        protected override async Task Handle(UpdateCountryRequest request, CancellationToken cancellationToken)
        {
            var country = _mapper.Map<Country>(request.Country);
            await _countryRepository.UpdateAsync(country);
        }
    }
}
