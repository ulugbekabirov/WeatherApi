using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Weather.RA.Interfaces;
using Weather.SDK.DTO;

namespace Weather.ServiceHost.Handlers.CountryHandlers
{
    public class GetAllCountriesRequest : IRequest<IActionResult>
    {
    }

    public class GetAllCountriesHandler : IRequestHandler<GetAllCountriesRequest, IActionResult>
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public GetAllCountriesHandler(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Handle(GetAllCountriesRequest request, CancellationToken cancellationToken)
        {
            var countries = await _countryRepository.GetAllAsync();
            return new OkObjectResult(_mapper.Map<CountryDTO[]>(countries));
        }
    }
}
