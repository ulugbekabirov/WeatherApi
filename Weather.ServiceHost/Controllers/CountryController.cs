using System;
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
        public async Task<IActionResult> GetCountries()
        {
            return await _mediator.Send(new GetAllCountriesRequest());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCountryById(Guid id)
        {
            return await _mediator.Send(new GetCountryRequest() { CountryId = id });
        }

        [HttpPost]
        public async Task<IActionResult> CreateCountry([FromBody] CreateCountryDTO country)
        {
            return await _mediator.Send(new CreateCountryRequest() { Country = country });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCountry(Guid id, [FromBody] CreateCountryDTO country)
        {
            return await _mediator.Send(new UpdateCountryRequest() { Id = id, Country = country });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(Guid id)
        {
            return await _mediator.Send(new DeleteCountryRequest() { CountryId = id });
        }
    }
}
