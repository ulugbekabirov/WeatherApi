using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Data.Entities
{
    public class Country
    {
        public Country()
        {
            Cities = new List<City>();
        }

        [Required]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(2)]
        public string AlphaCode { get; set; }

        public ICollection<City> Cities { get; set; }
    }
}
