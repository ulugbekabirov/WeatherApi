using AutoMapper;
using MediatR;
using Weather.SDK.Interfaces;

namespace Weather.ServiceHost.Services
{
    public class CityService : ICityService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CityService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
    }
}
