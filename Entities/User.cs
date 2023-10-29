using System;
using System.Collections.Generic;

namespace RentalCar.Entities;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Password { get; set; }

    public int? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<CarReview> CarReviews { get; set; } = new List<CarReview>();

    public virtual ICollection<Contactusquery> Contactusqueries { get; set; } = new List<Contactusquery>();

    public virtual ICollection<DrivingLicense> DrivingLicenses { get; set; } = new List<DrivingLicense>();

    public virtual ICollection<RentalRate> RentalRates { get; set; } = new List<RentalRate>();

    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();
}
