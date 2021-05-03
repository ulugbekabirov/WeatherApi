using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.SDK.DTO
{
    public class UpdateCountryDTO
    {
        public string Name { get; set; }

        public string AlphaCode { get; set; }

        public double Version { get; set; }
    }
}
