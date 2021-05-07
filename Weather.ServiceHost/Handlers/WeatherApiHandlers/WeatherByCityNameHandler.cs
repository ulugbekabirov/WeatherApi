using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Weather.ServiceHost.AppStart;

namespace Weather.ServiceHost.Handlers.WeatherApiHandlers
{
    public class WeatherByCityNameRequest : IRequest<IActionResult>
    {
        public string CityName { get; set; }

        public string APIKey { get; set; }
    }

    public class WeatherByCityNameHandler : IRequestHandler<WeatherByCityNameRequest, IActionResult>
    {
        public WeatherByCityNameHandler(IOptions<WeatherApiSettings> options)
        {

        }

        public async Task<IActionResult> Handle(WeatherByCityNameRequest request, CancellationToken cancellationToken)
        {
            var client = new HttpClient();

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://community-open-weather-map.p.rapidapi.com/find?q=london&cnt=0&mode=null&lon=0&type=link%2C%20accurate&lat=0&units=imperial%2C%20metric")
            };

            return request;
        }
    }
}
