using System.ComponentModel.DataAnnotations;

namespace RentalCar.Models.Gallery
{
    public class EditGallery
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int CarId { get; set; }

        [Required]
        public string Thumbnail { get; set; }
    }
}
