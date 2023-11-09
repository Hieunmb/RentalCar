using System.ComponentModel.DataAnnotations;

namespace RentalCar.Models.CarType
{
    public class EditCarType
    {
        [Required]
        public int id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên danh mục")]
        [MaxLength(255, ErrorMessage = "Nhập tối đa 255 kí tự")]
        public string name { get; set; }
        [Required]
        public string icon { get; set; }
        public string description { get; set; }
    }
}
