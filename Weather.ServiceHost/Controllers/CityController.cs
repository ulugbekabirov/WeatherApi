using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Weather.SDK.DTO;
using Weather.ServiceHost.Handlers.CityHandlers;

namespace Weather.ServiceHost.Controllers
{
    [Route("api/cities")]
    public class CityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            return await _mediator.Send(new GetAllCitiesRequest());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCityById(int id)
        {
            Ok(id);
            return await _mediator.Send(new GetCityRequest() { CityId = id });
        }

        [HttpPost]
        public async Task<IActionResult> CreateCity([FromBody] CreateCityDTO city)
        {
            return await _mediator.Send(new CreateCityRequest() { City = city });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCity(int id, [FromBody] CreateCityDTO city)
        {
            return await _mediator.Send(new UpdateCityRequest() { City = city });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            return await _mediator.Send(new DeleteCityRequest() { CityId = id });
        }
    }
}
