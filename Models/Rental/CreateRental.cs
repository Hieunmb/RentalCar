using System;
using System.ComponentModel.DataAnnotations;

namespace RentalCar.Models.Rental
{
    public class CreateRental
    {
        [Required]
        public int UsersId { get; set; }

        [Required]
        public int CarId { get; set; }

        [Required]
        public DateTime RentalDate { get; set; }

        [Required]
        public DateTime ReturnDate { get; set; }

        public int? Expected { get; set; }

        [Required]
        public string PickupLocation { get; set; }

        public string? Message { get; set; }

        public string? Address { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Telephone { get; set; }

        [Required]
        public string RentalType { get; set; }

        [Required]
        public decimal CarPrice { get; set; }

        [Required]
        public string DepositType { get; set; }

        [Required]
        public decimal DepositAmount { get; set; }

        [Required]
        public decimal AdditionalFee { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

        [Required]
        public int Status { get; set; }

        [Required]
        public string PaymentMethod { get; set; }

        public int? IsRentPaid { get; set; }

        public int? IsDepositPaid { get; set; }

        public int? IsCarReturned { get; set; }

        public int? IsDepositReturned { get; set; }

        public int? IsReviewed { get; set; }
    }
}
