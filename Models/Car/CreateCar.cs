using RentalCar.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentalCar.Models.Car
{
    public class CreateCar
    {
        [Required(ErrorMessage = "License plate cannot be empty.")]
        public string LicensePlate { get; set; }

        [Required(ErrorMessage = "Model cannot be empty.")]
        public string Model { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Invalid brand ID.")]
        public int BrandId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Invalid car type ID.")]
        public int CartypeId { get; set; }

        public string Thumbnail { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Invalid price.")]
        public decimal Price { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Invalid deposit.")]
        public decimal Deposit { get; set; }

        [Required(ErrorMessage = "Fuel type cannot be empty.")]
        public string FuelType { get; set; }

        [Required(ErrorMessage = "Transmission cannot be empty.")]
        public string Transmission { get; set; }

        [Required(ErrorMessage = "Km limit cannot be empty.")]
        public string KmLimit { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Invalid model year.")]
        public int ModelYear { get; set; }

        public int ReverseSensor { get; set; }

        public int AirConditioner { get; set; }

        public int DriverAirbag { get; set; }

        public int CDplayer { get; set; }

        public int BrakeAssist { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Invalid number of seats.")]
        public int Seats { get; set; }

        [Range(0, 1, ErrorMessage = "Invalid status.")]
        public int Status { get; set; }

        [Required(ErrorMessage = "Description cannot be empty.")]
        public string Description { get; set; }

        [Range(0, 5, ErrorMessage = "Invalid rating.")]
        public double Rate { get; set; }

        // Additional validation for galleries and car reviews if needed

    }
}
