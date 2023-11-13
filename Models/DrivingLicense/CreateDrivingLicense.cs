using System.ComponentModel.DataAnnotations;

namespace RentalCar.Models.DrivingLicense
{
    public class CreateDrivingLicense
    {
        [Required]
        public int UsersId { get; set; }

        [Required]
        public string Icon { get; set; }

        public string? Description { get; set; }
    }
}
