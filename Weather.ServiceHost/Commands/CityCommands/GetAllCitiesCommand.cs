using MediatR;
using System.Collections.Generic;
using Weather.SDK.DTO;

namespace Weather.ServiceHost.Commands.CityCommands
{
    public class GetAllCitiesCommand : IRequest<IEnumerable<CityDTO>>
    {
    }
}
