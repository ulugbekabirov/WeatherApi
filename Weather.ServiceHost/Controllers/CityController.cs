using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Weather.SDK.DTO;
using Weather.ServiceHost.Commands;

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
        public async Task<IEnumerable<string>> GetCities()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public async Task<string> GetCityById(int id)
        {
            return "value";
        }

        [HttpPost]
        public async Task CreateCity([FromBody] CityDTO city)
        {
            await _mediator.Send(new CreateCityCommand() { City = city });
        }

        [HttpPut("{id}")]
        public async Task UpdateCity(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public async Task DeleteCity(int id)
        {
        }
    }
}
