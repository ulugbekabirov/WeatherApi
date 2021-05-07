using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using Weather.ServiceHost.AppStart;

namespace Weather.ServiceHost.Handlers.WeatherApiHandlers
{
    public class WeatherByCityNameRequest : IRequest<IActionResult>
    {
        public string CityName { get; set; }
    }

    public class WeatherByCityNameHandler : IRequestHandler<WeatherByCityNameRequest, IActionResult>
    {
        private readonly string _apiKey;
        private readonly Uri _apiUrl;

        public WeatherByCityNameHandler(IOptions<WeatherApiSettings> options)
        {
            _apiKey = options.Value.Apikey;
            _apiUrl = options.Value.ApiUrl;
        }

        public async Task<IActionResult> Handle(WeatherByCityNameRequest request, CancellationToken cancellationToken)
        {
            var client = new HttpClient();

            var req = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(_apiUrl + $"?q={request.CityName}&appid={_apiKey}"),
            };

            var response = await client.SendAsync(req, cancellationToken);
            var body = await response.Content.ReadAsStringAsync(cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                return new BadRequestObjectResult(body);
            }

            return new OkObjectResult(body);
        }
    }
}
