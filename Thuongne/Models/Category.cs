using System;
using System.Collections.Generic;

namespace Thuongne.Models;

public partial class Category
{
    public int Id { get; set; }

    public string? CatName { get; set; }

    public string? Description { get; set; }

    public int? Ordering { get; set; }

    public bool? Published { get; set; }

    public string? Avatar { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
