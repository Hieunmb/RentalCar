using System.ComponentModel.DataAnnotations;

namespace RentalCar.Models.Car
{
    public class CreateCar
    {
        [Required]
        public string LicensePlate { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public int BrandId { get; set; }

        [Required]
        public int CartypeId { get; set; }

        [Required]
        public string Thumbnail { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public decimal Deposit { get; set; }

        [Required]
        public string FuelType { get; set; }

        [Required]
        public string Transmission { get; set; }

        [Required]
        public string KmLimit { get; set; }

        [Required]
        public int ModelYear { get; set; }

        [Required]
        public int ReverseSensor { get; set; }

        [Required]
        public int AirConditioner { get; set; }

        [Required]
        public int DriverAirbag { get; set; }

        [Required]
        public int CDplayer { get; set; }

        [Required]
        public int BrakeAssist { get; set; }

        [Required]
        public int Seats { get; set; }

        [Required]
        public int Status { get; set; }

        public string Description { get; set; }

        [Required]
        public double Rate { get; set; }
    }
}
