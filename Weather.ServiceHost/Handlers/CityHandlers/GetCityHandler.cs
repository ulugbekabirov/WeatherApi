using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Weather.RA.Interfaces;
using Weather.SDK.DTO;

namespace Weather.ServiceHost.Handlers.CityHandlers
{
    public class GetCityRequest : IRequest<IActionResult>
    {
        public Guid CityId { get; set; }
    }

    public class GetCityHandler : IRequestHandler<GetCityRequest, IActionResult>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public GetCityHandler(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Handle(GetCityRequest request, CancellationToken cancellationToken)
        {
            var city = await _cityRepository.GetByIdAsync(request.CityId);
            return new OkObjectResult(_mapper.Map<CityDTO>(city));
        }
    }
}
