using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public string AlphaCode { get; set; }

        public int Version { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<City> Cities { get; set; }
    }
}
