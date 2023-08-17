using System.ComponentModel.DataAnnotations;

namespace RentalApplication.Models
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        public int Year { get; set; }
    }
}
