using System;
using System.Collections.Generic;

namespace Thuongne.Models;

public partial class ColorProduct
{
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public string? NameColor { get; set; }

    public int? Quantity { get; set; }

    public int? QuantitySold { get; set; }

    public bool? Active { get; set; }

    public virtual Product? Product { get; set; }
}
