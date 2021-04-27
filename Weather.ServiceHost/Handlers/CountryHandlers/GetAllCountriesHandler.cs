using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Weather.RA.SqlRepositories;
using Weather.SDK.DTO;

namespace Weather.ServiceHost.Handlers.CountryHandlers
{
    public class GetAllCountriesRequest : IRequest<IEnumerable<CountryDTO>>
    {
    }

    public class GetAllCountriesHandler : IRequestHandler<GetAllCountriesRequest, IEnumerable<CountryDTO>>
    {
        private readonly CountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public GetAllCountriesHandler(CountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CountryDTO>> Handle(GetAllCountriesRequest request, CancellationToken cancellationToken)
        {
            var countries = await _countryRepository.GetAllAsync();
            return _mapper.Map<CountryDTO[]>(countries);
        }
    }
}
