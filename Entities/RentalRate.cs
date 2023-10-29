using System;
using System.Collections.Generic;

namespace RentalCar.Entities;

public partial class RentalRate
{
    public int Id { get; set; }

    public int UsersId { get; set; }

    public int RentalType { get; set; }

    public decimal Price { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual User Users { get; set; } = null!;
}
