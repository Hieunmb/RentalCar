using System.ComponentModel.DataAnnotations;

namespace RentalCar.Models.CarStatus
{
    public class EditCarStatus
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int RentalId { get; set; }

        [Required]
        public string Thumbnail1 { get; set; }

        [Required]
        public string Thumbnail2 { get; set; }
    }
}
