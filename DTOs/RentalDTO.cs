namespace RentalCar.DTOs
{
    public class RentalDTO
    {
        public int Id { get; set; }
        public int UsersId { get; set; }
        public int CarId { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int? Expected { get; set; }
        public string PickupLocation { get; set; }
        public string? Message { get; set; }
        public string? Address { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string RentalType { get; set; }
        public decimal CarPrice { get; set; }
        public string DepositType { get; set; }
        public decimal DepositAmount { get; set; }
        public decimal AdditionalFee { get; set; }
        public decimal TotalAmount { get; set; }
        public int Status { get; set; }
        public string PaymentMethod { get; set; }
        public int? IsRentPaid { get; set; }
        public int? IsDepositPaid { get; set; }
        public int? IsCarReturned { get; set; }
        public int? IsDepositReturned { get; set; }
        public int? IsReviewed { get; set; }
    }
}
