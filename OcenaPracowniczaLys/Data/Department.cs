using System;
using System.Collections.Generic;

namespace OcenaPracowniczaLys.Data;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string Name { get; set; } = null!;

    public bool Enabled { get; set; }

    public int? ManagerId { get; set; }

    public virtual ICollection<Evaluation> Evaluations { get; set; } = new List<Evaluation>();

    public virtual User? Manager { get; set; }
}
