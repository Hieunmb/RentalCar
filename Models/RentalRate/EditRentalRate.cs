using System.ComponentModel.DataAnnotations;

namespace RentalCar.Models.RentalRate
{
    public class EditRentalRate
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int UsersId { get; set; }

        [Required]
        public int RentalType { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
