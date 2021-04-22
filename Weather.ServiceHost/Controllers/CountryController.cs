using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Weather.ServiceHost.Controllers
{
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<string>> GetCountries()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public async Task<string> GetCountryById(int id)
        {
            return "value";
        }

        [HttpPost]
        public async Task CreateCountry([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public async Task UpdateCountry(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public async Task DeleteCountry(int id)
        {
        }
    }
}
