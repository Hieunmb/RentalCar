using System.ComponentModel.DataAnnotations;

namespace RentalCar.Models.Admin
{
    public class EditAdmin
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Fullname { get; set; }

        [Required]
        public string Icon { get; set; }

        [Required]
        public string Phone { get; set; }
    }
}
