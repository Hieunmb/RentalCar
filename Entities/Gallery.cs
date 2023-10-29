using System;
using System.Collections.Generic;

namespace RentalCar.Entities;

public partial class Gallery
{
    public int Id { get; set; }

    public int CarId { get; set; }

    public string Thumbnail { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Car Car { get; set; } = null!;
}
