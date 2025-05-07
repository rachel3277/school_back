using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Class
{
    public int Id { get; set; }

    public virtual ICollection<Event> Eventts { get; set; } = new List<Event>();
}
