using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Weather.ServiceHost.Handlers.WeatherApiHandlers;

namespace Weather.ServiceHost.Controllers
{
    [Route("api/weather")]
    [ApiController]
    public class WeatherApiController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WeatherApiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetWeatherByCityName(string cityName)
        {
            return await _mediator.Send(new WeatherByCityNameRequest() { CityName = cityName });
        }
    }
}
