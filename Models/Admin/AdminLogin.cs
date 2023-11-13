using System.ComponentModel.DataAnnotations;

namespace RentalCar.Models.Admin
{
    public class AdminLogin
    {
        [Required]
        public string Phone { get; set; }

        [Required]
        [MinLength(4)]
        public string Password { get; set; }
    }
}
