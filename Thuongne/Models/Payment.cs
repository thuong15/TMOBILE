using System;
using System.Collections.Generic;

namespace Thuongne.Models;

public partial class Payment
{
    public int Id { get; set; }

    public string? PayName { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
