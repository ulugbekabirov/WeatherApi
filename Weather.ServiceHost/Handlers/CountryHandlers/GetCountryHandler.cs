using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Weather.RA.Interfaces;
using Weather.SDK.DTO;

namespace Weather.ServiceHost.Handlers.CountryHandlers
{
    public class GetCountryRequest : IRequest<CountryDTO>
    {
        public int CountryId { get; set; }
    }

    public class GetCountryHandler : IRequestHandler<GetCountryRequest, CountryDTO>
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public GetCountryHandler(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task<CountryDTO> Handle(GetCountryRequest request, CancellationToken cancellationToken)
        {
            var country = await _countryRepository.GetByIdAsync(request.CountryId);
            return _mapper.Map<CountryDTO>(country);
        }
    }
}
