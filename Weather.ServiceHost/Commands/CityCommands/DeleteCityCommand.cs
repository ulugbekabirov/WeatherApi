using MediatR;

namespace Weather.ServiceHost.Commands.CityCommands
{
    public class DeleteCityCommand: IRequest
    {
        public int CityId { get; set; }
    }
}
