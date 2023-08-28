using System;
using System.Collections.Generic;

namespace Thuongne.Models;

public partial class Order
{
    public int Id { get; set; }

    public int? AccountId { get; set; }

    public DateTime? OrderDate { get; set; }

    public DateTime? ShipDate { get; set; }

    public int? TransactStatusId { get; set; }

    public bool? Deleted { get; set; }

    public bool? Paid { get; set; }

    public int? CatNumber { get; set; }

    public DateTime? PaymentDate { get; set; }

    public int? PaymentId { get; set; }

    public int? AddressId { get; set; }

    public string? Note { get; set; }

    public virtual Account? Account { get; set; }

    public virtual Address? Address { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Payment? Payment { get; set; }

    public virtual TransactStatus? TransactStatus { get; set; }
}
