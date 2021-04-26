using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Weather.SDK.DTO;
using Weather.ServiceHost.Commands.CountryCommands;

namespace Weather.ServiceHost.Controllers
{
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CountryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<CountryDTO>> GetCountries()
        {
            return await _mediator.Send(new GetAllCountriesCommand());
        }

        [HttpGet("{id}")]
        public async Task<CountryDTO> GetCountryById(int id)
        {
            return await _mediator.Send(new GetCountryCommand() { CountryId = id });
        }

        [HttpPost]
        public async Task CreateCountry([FromBody] CountryDTO country)
        {
            await _mediator.Send(new CreateCountryCommand() { Country = country });
        }

        [HttpPut("{id}")]
        public async Task UpdateCountry(int id, [FromBody] CountryDTO country)
        {
            await _mediator.Send(new UpdateCountryCommand() { Country = country });
        }

        [HttpDelete("{id}")]
        public async Task DeleteCountry(int id)
        {
            await _mediator.Send(new DeleteCountryCommand() { CountryId = id });
        }
    }
}
