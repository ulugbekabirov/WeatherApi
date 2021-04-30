using System;

namespace Weather.SDK.DTO
{
    public class CityDTO
    {
        public Guid Id { get; set; }

        public Guid CountryId { get; set; }

        public string Name { get; set; }

        public double Version { get; set; }
    }
}
