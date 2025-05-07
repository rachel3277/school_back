using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Event
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public double Price { get; set; }

    public string? Place { get; set; }

    public short MinClass { get; set; }

    public short MaxClass { get; set; }

    public virtual ICollection<Registration> Registrations { get; set; } = new List<Registration>();

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();
}
