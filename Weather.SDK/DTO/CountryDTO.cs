using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.SDK.DTO
{
    public class CountryDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string AlphaCode { get; set; }
    }
}
