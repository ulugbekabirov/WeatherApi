using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Data.Entities
{
    public class City
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public double Temperature { get; set; }

        public double Version { get; set; }

        public bool IsDeleted { get; set; }
    }
}
