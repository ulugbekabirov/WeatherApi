using MediatR;
using Weather.SDK.DTO;

namespace Weather.ServiceHost.Commands
{
    public class CreateCityCommand: IRequest
    {
        public CityDTO City { get; set; }
    }
}
