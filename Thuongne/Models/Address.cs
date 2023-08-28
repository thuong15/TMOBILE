using System;
using System.Collections.Generic;

namespace Thuongne.Models;

public partial class Address
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Address1 { get; set; }

    public string? Phone { get; set; }

    public bool? Active { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
