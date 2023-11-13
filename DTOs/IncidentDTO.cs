namespace RentalCar.DTOs
{
    public class IncidentDTO
    {
        public int Id { get; set; }
        public int RentalId { get; set; }
        public string Title { get; set; }
        public string Thumbnail { get; set; }
        public string Description { get; set; }
        public decimal? Expense { get; set; }
    }
}