using System;
using System.Collections.Generic;

namespace Thuongne.Models;

public partial class News
{
    public int Id { get; set; }

    public string? Thumbnail { get; set; }

    public int? CatId { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }

    public DateTime? CreateDate { get; set; }

    public bool? Active { get; set; }

    public string? Link { get; set; }
}
