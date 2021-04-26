using MediatR;
using Weather.SDK.DTO;

namespace Weather.ServiceHost.Commands.CityCommands
{
    public class CreateCityCommand: IRequest
    {
        public CityDTO City { get; set; }
    }
}
