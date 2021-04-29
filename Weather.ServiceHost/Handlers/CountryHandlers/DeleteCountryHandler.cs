using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Weather.RA.Interfaces;

namespace Weather.ServiceHost.Handlers.CountryHandlers
{
    public class DeleteCountryRequest : IRequest
    {
        public int CountryId { get; set; }
    }

    public class DeleteCountryHandler : AsyncRequestHandler<DeleteCountryRequest>
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public DeleteCountryHandler(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        protected override async Task Handle(DeleteCountryRequest request, CancellationToken cancellationToken)
        {
            await _countryRepository.DeleteSoftlyAsync(request.CountryId);
        }
    }
}
