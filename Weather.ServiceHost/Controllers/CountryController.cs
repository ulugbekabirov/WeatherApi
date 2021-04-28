using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Weather.SDK.DTO;
using Weather.ServiceHost.Handlers.CountryHandlers;

namespace Weather.ServiceHost.Controllers
{
    [Route("api/countries")]
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
            return await _mediator.Send(new GetAllCountriesRequest());
        }

        [HttpGet("{id}")]
        public async Task<CountryDTO> GetCountryById(int id)
        {
            return await _mediator.Send(new GetCountryRequest() { CountryId = id });
        }

        [HttpPost]
        public async Task CreateCountry([FromBody] CountryDTO country)
        {
            await _mediator.Send(new CreateCountryRequest() { Country = country });
        }

        [HttpPut("{id}")]
        public async Task UpdateCountry(int id, [FromBody] CountryDTO country)
        {
            await _mediator.Send(new UpdateCountryRequest() { Country = country });
        }

        [HttpDelete("{id}")]
        public async Task DeleteCountry(int id)
        {
            await _mediator.Send(new DeleteCountryRequest() { CountryId = id });
        }
    }
}
