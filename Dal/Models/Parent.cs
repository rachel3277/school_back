using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Parent
{
    public int Id { get; set; }

    public bool Accepted { get; set; }

    public string FamilyLastName { get; set; } = null!;

    public string MotherFirstName { get; set; } = null!;

    public string FatherFirstName { get; set; } = null!;

    public string? HomeNumberPhone { get; set; }

    public string NumberPhone1 { get; set; } = null!;

    public string NumberPhone2 { get; set; } = null!;

    public string Mail { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
