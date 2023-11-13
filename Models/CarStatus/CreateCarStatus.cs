using System.ComponentModel.DataAnnotations;

namespace RentalCar.Models.CarStatus
{
    public class CreateCarStatus
    {
        [Required]
        public int RentalId { get; set; }

        [Required]
        public string Thumbnail1 { get; set; }

        [Required]
        public string Thumbnail2 { get; set; }
    }
}
