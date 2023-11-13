using System.ComponentModel.DataAnnotations;

namespace RentalCar.Models.DrivingLicense
{
    public class EditDrivingLicense
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int UsersId { get; set; }

        [Required]
        public string Icon { get; set; }

        public string? Description { get; set; }
    }
}
