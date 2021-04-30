using System;

namespace Weather.SDK.DTO
{
    public class UpdateCityDTO
    {
        public Guid CountryId { get; set; }

        public string Name { get; set; }

        public double Version { get; set; }
    }
}
