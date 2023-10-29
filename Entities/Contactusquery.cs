using System;
using System.Collections.Generic;

namespace RentalCar.Entities;

public partial class Contactusquery
{
    public int Id { get; set; }

    public int UsersId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? Message { get; set; }

    public int Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual User Users { get; set; } = null!;
}
