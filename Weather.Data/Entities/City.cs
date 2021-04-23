using System.ComponentModel.DataAnnotations;

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
