using System.ComponentModel.DataAnnotations;
using System;
namespace RentalCar.Models.Brand
{
    public class EditBrand
    {
        [Required]
        public int id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên danh mục")]
        [MaxLength(255, ErrorMessage = "Nhập tối đa 255 kí tự")]
        public string name { get; set; }
        [Required]
        public string icon { get; set; }
    }
}
