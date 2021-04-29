using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Weather.RA.Interfaces;

namespace Weather.ServiceHost.Handlers.CountryHandlers
{
    public class DeleteCountryRequest : IRequest<IActionResult>
    {
        public int CountryId { get; set; }
    }

    public class DeleteCountryHandler : IRequestHandler<DeleteCountryRequest, IActionResult>
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public DeleteCountryHandler(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Handle(DeleteCountryRequest request, CancellationToken cancellationToken)
        {
            await _countryRepository.DeleteSoftlyAsync(request.CountryId);
            return new OkResult();
        }
    }
}
