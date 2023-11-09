using System.ComponentModel.DataAnnotations;

namespace RentalCar.Models.CarType
{
    public class CreateCarType
    {
        [Required]
        [MaxLength(255, ErrorMessage = "Nhap toi thieu 255 ki tu")]
        public string name { get; set; }
        [Required]
        public string icon { get; set; }
        public string description { get; set; }
    }
}
