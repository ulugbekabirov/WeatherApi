using System;

namespace Weather.SDK.DTO
{
    public class CountryDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string AlphaCode { get; set; }

        public double Version { get; set; }
    }
}
