using System.ComponentModel.DataAnnotations;

namespace RentalCar.Models.CarReview
{
    public class CreateCarReview
    {
        [Required]
        public int UsersId { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public int Score { get; set; }

        [Required]
        public int CarId { get; set; }
    }
}
