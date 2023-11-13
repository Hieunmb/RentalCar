using System.ComponentModel.DataAnnotations;

namespace RentalCar.Models.Service
{
    public class CreateService
    {
        [Required]
        public int RentalId { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public decimal? Price { get; set; }
    }
}
