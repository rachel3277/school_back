using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Registration
{
    public int EventId { get; set; }

    public int StudentId { get; set; }

    public DateTime? Date { get; set; }

    public virtual Event Event { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
