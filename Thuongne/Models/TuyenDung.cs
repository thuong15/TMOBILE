using System;
using System.Collections.Generic;

namespace Thuongne.Models;

public partial class TuyenDung
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? WorkTime { get; set; }

    public string? Adress { get; set; }

    public string? Require { get; set; }

    public string? Benefit { get; set; }

    public string? Contact { get; set; }

    public bool? Active { get; set; }
}
