using MediatR;

namespace Weather.ServiceHost.Commands.CountryCommands
{
    public class DeleteCountryCommand : IRequest
    {
        public int CountryId { get; set; }
    }
}
