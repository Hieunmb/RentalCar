namespace RentalCar.DTOs
{
    public class CarDTO
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; }
        public string Model { get; set; }
        public int BrandId { get; set; }
        public int CartypeId { get; set; }
        public string Thumbnail { get; set; }
        public decimal Price { get; set; }
        public decimal Deposit { get; set; }
        public string FuelType { get; set; }
        public string Transmission { get; set; }
        public string KmLimit { get; set; }
        public int ModelYear { get; set; }
        public int ReverseSensor { get; set; }
        public int AirConditioner { get; set; }
        public int DriverAirbag { get; set; }
        public int CDplayer { get; set; }
        public int BrakeAssist { get; set; }
        public int Seats { get; set; }
        public int Status { get; set; }
        public string Description { get; set; }
        public double Rate { get; set; }
    }
}
