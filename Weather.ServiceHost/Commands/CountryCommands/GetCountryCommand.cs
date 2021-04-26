using MediatR;
using Weather.SDK.DTO;

namespace Weather.ServiceHost.Commands.CountryCommands
{
    public class GetCountryCommand : IRequest<CountryDTO>
    {
        public int CountryId { get; set; }
    }
}
