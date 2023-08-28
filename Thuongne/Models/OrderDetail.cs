using System;
using System.Collections.Generic;

namespace Thuongne.Models;

public partial class OrderDetail
{
    public int Id { get; set; }

    public int? OrderId { get; set; }

    public int? ProducId { get; set; }

    public int? Quantity { get; set; }

    public int? Discount { get; set; }

    public int? Total { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Product? Produc { get; set; }
}
