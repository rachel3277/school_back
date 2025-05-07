using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Student
{
    public int Id { get; set; }

    public bool Accepted { get; set; }

    public string Name { get; set; } = null!;

    public int Class { get; set; }

    public int ParentsId { get; set; }

    public virtual Parent Parents { get; set; } = null!;

    public virtual ICollection<Registration> Registrations { get; set; } = new List<Registration>();
}
