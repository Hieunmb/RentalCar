using System;
using System.Collections.Generic;

namespace RentalCar.Entities;

public partial class Rental
{
    public int Id { get; set; }

    public int UsersId { get; set; }

    public int CarId { get; set; }

    public DateTime RentalDate { get; set; }

    public DateTime ReturnDate { get; set; }

    public int? Expected { get; set; }

    public string PickupLocation { get; set; } = null!;

    public string? Message { get; set; }

    public string? Address { get; set; }

    public string Email { get; set; } = null!;

    public string Telephone { get; set; } = null!;

    public string RentalType { get; set; } = null!;

    public decimal CarPrice { get; set; }

    public string DepositType { get; set; } = null!;

    public decimal DepositAmount { get; set; }

    public decimal AdditionalFee { get; set; }

    public decimal TotalAmount { get; set; }

    public int Status { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public int? IsRentPaid { get; set; }

    public int? IsDepositPaid { get; set; }

    public int? IsCarReturned { get; set; }

    public int? IsDepositReturned { get; set; }

    public int? IsReviewed { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Car Car { get; set; } = null!;

    public virtual ICollection<CarStatus> CarStatuses { get; set; } = new List<CarStatus>();

    public virtual ICollection<Incident> Incidents { get; set; } = new List<Incident>();

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();

    public virtual User Users { get; set; } = null!;
}
