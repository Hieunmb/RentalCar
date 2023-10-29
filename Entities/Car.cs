using System;
using System.Collections.Generic;

namespace RentalCar.Entities;

public partial class Car
{
    public int Id { get; set; }

    public string LicensePlate { get; set; } = null!;

    public string Model { get; set; } = null!;

    public int BrandId { get; set; }

    public int CartypeId { get; set; }

    public string Thumbnail { get; set; } = null!;

    public decimal Price { get; set; }

    public decimal Deposit { get; set; }

    public string FuelType { get; set; } = null!;

    public string Transmission { get; set; } = null!;

    public string KmLimit { get; set; } = null!;

    public int ModelYear { get; set; }

    public int ReverseSensor { get; set; }

    public int AirConditioner { get; set; }

    public int DriverAirbag { get; set; }

    public int CDplayer { get; set; }

    public int BrakeAssist { get; set; }

    public int Seats { get; set; }

    public int Status { get; set; }

    public string? Description { get; set; }

    public double Rate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Brand Brand { get; set; } = null!;

    public virtual ICollection<CarReview> CarReviews { get; set; } = new List<CarReview>();

    public virtual Cartype Cartype { get; set; } = null!;

    public virtual ICollection<Gallery> Galleries { get; set; } = new List<Gallery>();

    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();
}
