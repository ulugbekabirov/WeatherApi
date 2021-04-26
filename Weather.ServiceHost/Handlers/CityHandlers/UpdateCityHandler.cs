using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Weather.ServiceHost.Commands.CityCommands;

namespace Weather.ServiceHost.Handlers.CityHandlers
{
    public class UpdateCityHandler : AsyncRequestHandler<UpdateCityCommand>
    {
        protected override Task Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
