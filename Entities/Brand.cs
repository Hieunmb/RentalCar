using System;
using System.Collections.Generic;

namespace RentalCar.Entities;

public partial class Brand
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Icon { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}
