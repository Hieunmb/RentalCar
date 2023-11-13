using System.ComponentModel.DataAnnotations;

namespace RentalCar.Models.Contactusquery
{
    public class CreateContactusquery
    {
        [Required]
        public int UsersId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        public string? Message { get; set; }

        [Required]
        public int Status { get; set; }
    }
}
