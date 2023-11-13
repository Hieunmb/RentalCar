namespace RentalCar.DTOs
{
    public class CarReviewDTO
    {
        public int Id { get; set; }
        public int UsersId { get; set; }
        public string Message { get; set; }
        public int Score { get; set; }
        public int CarId { get; set; }
    }
}
