using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Weather.RA.SqlRepositories;
using Weather.SDK.DTO;
using Weather.ServiceHost.Commands.CountryCommands;

namespace Weather.ServiceHost.Handlers.CountryHandlers
{
    public class GetCountryHandler : IRequestHandler<GetCountryCommand, CountryDTO>
    {
        private readonly CountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public GetCountryHandler(CountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task<CountryDTO> Handle(GetCountryCommand request, CancellationToken cancellationToken)
        {
            var country = await _countryRepository.GetByIdAsync(request.CountryId);
            return _mapper.Map<CountryDTO>(country);
        }
    }
}
