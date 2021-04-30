using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Weather.RA.Interfaces;

namespace Weather.ServiceHost.Handlers.CityHandlers
{
    public class DeleteCityRequest : IRequest<IActionResult>
    {
        public Guid CityId { get; set; }
    }

    public class DeleteCityHandler : IRequestHandler<DeleteCityRequest, IActionResult>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public DeleteCityHandler(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Handle(DeleteCityRequest request, CancellationToken cancellationToken)
        {
            await _cityRepository.DeleteSoftlyAsync(request.CityId);
            return new OkResult();
        }
    }
}
