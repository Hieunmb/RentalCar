using System.ComponentModel.DataAnnotations;

namespace RentalCar.Models.Service
{
    public class EditService
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int RentalId { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public decimal? Price { get; set; }
    }
}
