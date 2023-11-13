namespace RentalCar.DTOs
{
    public class ServiceDTO
    {
        public int Id { get; set; }
        public int RentalId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
    }
}
