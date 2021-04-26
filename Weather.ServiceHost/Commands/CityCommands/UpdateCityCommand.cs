using MediatR;

namespace Weather.ServiceHost.Commands.CityCommands
{
    public class UpdateCityCommand : IRequest
    {
        public int CityId { get; set; }
    }
}
