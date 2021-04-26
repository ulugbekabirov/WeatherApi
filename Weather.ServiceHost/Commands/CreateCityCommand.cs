using MediatR;
using Weather.Data.Entities;

namespace Weather.ServiceHost.Commands
{
    public class CreateCityCommand: IRequest
    {
        public City City { get; set; }
    }
}
