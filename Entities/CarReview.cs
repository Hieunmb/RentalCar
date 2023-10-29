using System;
using System.Collections.Generic;

namespace RentalCar.Entities;

public partial class CarReview
{
    public int Id { get; set; }

    public int UsersId { get; set; }

    public string Message { get; set; } = null!;

    public int Score { get; set; }

    public int CarId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Car Car { get; set; } = null!;

    public virtual User Users { get; set; } = null!;
}
