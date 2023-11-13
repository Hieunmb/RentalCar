using System.ComponentModel.DataAnnotations;

namespace RentalCar.Models.Gallery
{
    public class CreateGallery
    {
        [Required]
        public int CarId { get; set; }

        [Required]
        public string Thumbnail { get; set; }
    }
}
