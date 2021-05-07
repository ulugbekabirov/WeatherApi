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
    public class UpdateCountryRequest : IRequest<IActionResult>
    {
        public Guid Id { get; set; }

        public UpdateCountryDTO Country { get; set; }
    }

    public class UpdateCountryHandler : IRequestHandler<UpdateCountryRequest, IActionResult>
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        private readonly UpdateCountryValidator _countryValidator;

        public UpdateCountryHandler(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
            _countryValidator = new UpdateCountryValidator(_countryRepository);
        }

        public async Task<IActionResult> Handle(UpdateCountryRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _countryValidator.ValidateAsync(request.Country, cancellationToken);

            if (!validationResult.IsValid)
            {
                return new BadRequestObjectResult(validationResult.Errors);
            }

            var country = await _countryRepository.GetByIdAsync(request.Id);

            if (country.Version > request.Country.Version)
            {
                return new ConflictObjectResult("Version mismatch");
            }

            country = _mapper.Map<Country>(request.Country);
            await _countryRepository.UpdateAsync(country);
            return new NoContentResult();
        }
    }
}
