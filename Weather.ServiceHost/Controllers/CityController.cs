using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Weather.ServiceHost.Controllers
{
    [Route("api/city")]
    public class CityController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<string>> GetCities()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public async Task<string> GetCityById(int id)
        {
            return "value";
        }

        [HttpPost]
        public async Task CreateCity([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public async Task UpdateCity(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public async Task DeleteCity(int id)
        {
        }
    }
}
