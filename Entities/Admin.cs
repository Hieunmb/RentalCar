using System;
using System.Collections.Generic;

namespace RentalCar.Entities;

public partial class Admin
{
    public int Id { get; set; }

    public string Fullname { get; set; } = null!;

    public string Icon { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }
}
