using System.ComponentModel.DataAnnotations;

namespace RentalCar.Models.RentalRate
{
    public class CreateRentalRate
    {
        [Required]
        public int UsersId { get; set; }

        [Required]
        public int RentalType { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
