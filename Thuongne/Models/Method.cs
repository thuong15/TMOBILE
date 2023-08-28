using System;
using System.Collections.Generic;

namespace Thuongne.Models;

public partial class Method
{
    public int Id { get; set; }

    public string? MetName { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
