using System;
using System.ComponentModel.DataAnnotations;

namespace Weather.Data.Entities
{
    public class City
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid CountryId { get; set; }

        [Required]
        public string Name { get; set; }

        public int Version { get; set; }

        public bool IsDeleted { get; set; }
    }
}
