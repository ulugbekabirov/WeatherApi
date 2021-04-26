using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Weather.RA.SqlRepositories;
using Weather.ServiceHost.Commands.CountryCommands;

namespace Weather.ServiceHost.Handlers.CountryHandlers
{
    public class UpdateCountryHandler : AsyncRequestHandler<UpdateCountryCommand>
    {
        private readonly CountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public UpdateCountryHandler(CountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        protected override async Task Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
