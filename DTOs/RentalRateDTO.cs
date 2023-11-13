namespace RentalCar.DTOs
{
    public class RentalRateDTO
    {
        public int Id { get; set; }
        public int UsersId { get; set; }
        public int RentalType { get; set; }
        public decimal Price { get; set; }
    }
}