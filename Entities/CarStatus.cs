using System;
using System.Collections.Generic;

namespace RentalCar.Entities;

public partial class CarStatus
{
    public int Id { get; set; }

    public int RentalId { get; set; }

    public string Thumbnail1 { get; set; } = null!;

    public string Thumbnail2 { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Rental Rental { get; set; } = null!;
}
