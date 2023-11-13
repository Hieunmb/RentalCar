using System.ComponentModel.DataAnnotations;

namespace RentalCar.Models.User
{
    public class UserLogin
    {
        [Required]
        public string email { get; set; }
        [Required]
        [MinLength(4)]
        public string password { get; set; }
    }
}
