using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weather.ServiceHost.AppStart
{
    public class WeatherApiSettings
    {
        public string Apikey { get; set; }

        public Uri ApiUrl { get; set; }
    }
}
