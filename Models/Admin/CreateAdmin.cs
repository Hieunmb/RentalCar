using System.ComponentModel.DataAnnotations;

namespace RentalCar.Models.Admin
{
    public class CreateAdmin
    {
        [Required]
        public string Fullname { get; set; }

        [Required]
        public string Icon { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
