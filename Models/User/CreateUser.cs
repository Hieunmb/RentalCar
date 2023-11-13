using System.ComponentModel.DataAnnotations;

namespace RentalCar.Models.User
{
    public class CreateUser
    {
        [Required]
        [MaxLength(255, ErrorMessage = "Enter up to 255 characters")]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string Email { get; set; }

        public string? Phone { get; set; }

        [Required]
        public string? Password { get; set; }

        public int? Status { get; set; }
    }
}
