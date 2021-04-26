using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Weather.SDK.DTO;
using Weather.ServiceHost.Commands.CityCommands;

namespace Weather.ServiceHost.Controllers
{
    [Route("api/city")]
    public class CityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<CityDTO>> GetCities()
        {
            return await _mediator.Send(new GetAllCitiesCommand());
        }

        [HttpGet("{id}")]
        public async Task<CityDTO> GetCityById(int id)
        {
            return await _mediator.Send(new GetCityCommand() { CityId = id });
        }

        [HttpPost]
        public async Task CreateCity([FromBody] CityDTO city)
        {
            await _mediator.Send(new CreateCityCommand() { City = city });
        }

        [HttpPut("{id}")]
        public async Task UpdateCity(int id, [FromBody] CityDTO city)
        {
            await _mediator.Send(new UpdateCityCommand() { City = city });
        }

        [HttpDelete("{id}")]
        public async Task DeleteCity(int id)
        {
            await _mediator.Send(new DeleteCityCommand() { CityId = id });
        }
    }
}
