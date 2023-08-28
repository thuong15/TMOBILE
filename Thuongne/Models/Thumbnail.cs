using System;
using System.Collections.Generic;

namespace Thuongne.Models;

public partial class Thumbnail
{
    public int Id { get; set; }

    public string? Thumb { get; set; }

    public int? ProId { get; set; }

    public virtual Product? Pro { get; set; }
}
