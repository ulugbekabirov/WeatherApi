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

namespace Weather.ServiceHost.Handlers.CityHandlers
{
    public class UpdateCityRequest : IRequest<IActionResult>
    {
        public Guid Id { get; set; }

        public UpdateCityDTO City { get; set; }
    }

    public class UpdateCityHandler : IRequestHandler<UpdateCityRequest, IActionResult>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;
        private readonly UpdateCityValidator _cityValidator;

        public UpdateCityHandler(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
            _cityValidator = new UpdateCityValidator(_cityRepository);
        }

        public async Task<IActionResult> Handle(UpdateCityRequest request, CancellationToken cancellationToken)
        {

            var validationResult = await _cityValidator.ValidateAsync(request.City);

            if (!validationResult.IsValid)
            {
                return new BadRequestObjectResult(validationResult.Errors);
            }

            var city = await _cityRepository.GetByIdAsync(request.Id);

            if (city.Version > request.City.Version)
            {
                return new ConflictObjectResult("Version mismatch");
            }

            city = _mapper.Map<City>(request.City);
            await _cityRepository.UpdateAsync(city);
            return new NoContentResult();
        }
    }
}
