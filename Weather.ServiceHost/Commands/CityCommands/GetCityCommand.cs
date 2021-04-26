using MediatR;
using Weather.SDK.DTO;

namespace Weather.ServiceHost.Commands.CityCommands
{
    public class GetCityCommand : IRequest<CityDTO>
    {
        public int CityId { get; set; }
    }
}
