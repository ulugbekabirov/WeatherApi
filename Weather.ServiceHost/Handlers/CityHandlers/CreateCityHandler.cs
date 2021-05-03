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
    public class CreateCityRequest : IRequest<IActionResult>
    {
        public CreateCityDTO City { get; set; }
    }

    public class CreateCityHandler : IRequestHandler<CreateCityRequest, IActionResult>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;
        private readonly CityValidator _cityValidator; 

        public CreateCityHandler(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
            _cityValidator = new CityValidator(_cityRepository);
        }

        public async Task<IActionResult> Handle(CreateCityRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _cityValidator.ValidateAsync(request.City);

            if (!validationResult.IsValid)
            {
                return new BadRequestObjectResult(validationResult.Errors);
            }

            var city = _mapper.Map<City>(request.City);
            city = await _cityRepository.CreateAsync(city);
            return new OkObjectResult(_mapper.Map<CityDTO>(city));
        }
    }
}
