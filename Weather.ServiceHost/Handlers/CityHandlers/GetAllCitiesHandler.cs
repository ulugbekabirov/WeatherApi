using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Weather.RA.Interfaces;
using Weather.SDK.DTO;

namespace Weather.ServiceHost.Handlers.CityHandlers
{
    public class GetAllCitiesRequest : IRequest<IActionResult>
    {
    }

    public class GetAllCitiesHandler : IRequestHandler<GetAllCitiesRequest, IActionResult>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public GetAllCitiesHandler(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Handle(GetAllCitiesRequest request, CancellationToken cancellationToken)
        {
            var cities = await _cityRepository.GetAllAsync();
            return _mapper.Map<CityDTO[]>(cities);
        }
    }
}
