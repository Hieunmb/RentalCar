namespace RentalCar.DTOs
{
    public class ContactusqueryDTO
    {
        public int Id { get; set; }
        public int UsersId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string? Message { get; set; }
        public int Status { get; set; }
    }
}
