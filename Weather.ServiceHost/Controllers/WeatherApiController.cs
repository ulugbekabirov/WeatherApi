using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Weather.ServiceHost.Controllers
{
    [Route("api/[]")]
    [ApiController]
    public class WeatherApiController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WeatherApiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            return;
        }
    }
}
