using System;

namespace Weather.SDK.DTO
{
    public class CreateCityDTO
    {
        public string Name { get; set; }

        public Guid CountryId { get; set; }
    }
}
