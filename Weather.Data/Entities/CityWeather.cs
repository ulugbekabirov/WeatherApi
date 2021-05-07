using System;

namespace Weather.Data.Entities
{
    public class CityWeather
    {
        public Guid CityWeatherId { get; set; }

        public Coordinate Coordinate { get; set; }

        public Weather Weather { get; set; }

        public string Base { get; set; }

        public Main Main { get; set; }

        public Wind Wind { get; set; }

        public Clouds Clouds { get; set; }

        public Rain Rain { get; set; }

        public Snow Snow { get; set; }

        public long DateTime { get; set; }

        public long TimeZone { get; set; }

        public string CityName { get; set; }
    }
}
