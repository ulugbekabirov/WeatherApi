using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Weather.RA.Interfaces;
using Weather.SDK.DTO;

namespace Weather.ServiceHost.Handlers.CountryHandlers
{
    public class GetCountryRequest : IRequest<IActionResult>
    {
        public Guid CountryId { get; set; }
    }

    public class GetCountryHandler : IRequestHandler<GetCountryRequest, IActionResult>
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public GetCountryHandler(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Handle(GetCountryRequest request, CancellationToken cancellationToken)
        {
            var country = await _countryRepository.GetByIdAsync(request.CountryId);
            return new OkObjectResult(_mapper.Map<CountryDTO>(country));
        }
    }
}
