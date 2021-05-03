using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Weather.Data.Entities;
using Weather.RA.Interfaces;
using Weather.SDK.DTO;
using Weather.ServiceHost.Validators;

namespace Weather.ServiceHost.Handlers.CountryHandlers
{
    public class CreateCountryRequest : IRequest<IActionResult>
    {
        public CreateCountryDTO Country { get; set; }
    }

    public class CreateCountryHandler : IRequestHandler<CreateCountryRequest, IActionResult>
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        private readonly CountryValidator _countryValidator;

        public CreateCountryHandler(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
            _countryValidator = new CountryValidator(_countryRepository);
        }

        public async Task<IActionResult> Handle(CreateCountryRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _countryValidator.ValidateAsync(request.Country);

            if (!validationResult.IsValid)
            {
                return new BadRequestObjectResult(validationResult.Errors);
            }

            var country = _mapper.Map<Country>(request.Country);
            country = await _countryRepository.CreateAsync(country);
            return new CreatedAtRouteResult(country.Id, _mapper.Map<CountryDTO>(country));
        }
    }
}
