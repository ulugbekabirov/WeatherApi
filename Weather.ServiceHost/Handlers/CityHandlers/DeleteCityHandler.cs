using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Weather.ServiceHost.Commands.CityCommands;

namespace Weather.ServiceHost.Handlers.CityHandlers
{
    public class DeleteCityHandler : AsyncRequestHandler<DeleteCityCommand>
    {
        protected override Task Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
