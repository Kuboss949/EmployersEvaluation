using System;
using System.Collections.Generic;

namespace OcenaPracowniczaLys.Data;

public partial class MainDepartment
{
    public int MainDepartmentId { get; set; }

    public string Name { get; set; } = null!;

    public bool? Enabled { get; set; }

    public virtual ICollection<Evaluation> Evaluations { get; set; } = new List<Evaluation>();

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
}
