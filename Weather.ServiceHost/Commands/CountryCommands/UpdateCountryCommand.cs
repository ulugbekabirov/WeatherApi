using MediatR;
using Weather.SDK.DTO;

namespace Weather.ServiceHost.Commands.CountryCommands
{
    public class UpdateCountryCommand : IRequest
    {
        public CountryDTO Country { get; set; }
    }
}
