using MediatR;
using Weather.SDK.DTO;

namespace Weather.ServiceHost.Commands.CityCommands
{
    public class UpdateCityCommand : IRequest
    {
        public CityDTO City { get; set; }
    }
}
