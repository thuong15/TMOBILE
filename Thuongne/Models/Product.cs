using System;
using System.Collections.Generic;

namespace Thuongne.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? ProName { get; set; }

    public string? ShortDesc { get; set; }

    public int? CatId { get; set; }

    public int? MethodId { get; set; }

    public int? Price { get; set; }

    public int? Discount { get; set; }

    public DateTime? CreateDate { get; set; }

    public bool? BestSeller { get; set; }

    public bool? Active { get; set; }

    public int? UnitslnStock { get; set; }

    public int? QuantitySold { get; set; }

    public int? Star { get; set; }

    public string? Screen { get; set; }

    public string? OperatingSystem { get; set; }

    public string? RearCam { get; set; }

    public string? FrontCam { get; set; }

    public string? Cpu { get; set; }

    public string? Ram { get; set; }

    public string? Rom { get; set; }

    public string? MemoryStick { get; set; }

    public string? BatteryCapacity { get; set; }

    public virtual Category? Cat { get; set; }

    public virtual ICollection<ColorProduct> ColorProducts { get; set; } = new List<ColorProduct>();

    public virtual Method? Method { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<Thumbnail> Thumbnails { get; set; } = new List<Thumbnail>();
}
