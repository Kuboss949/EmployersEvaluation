using System;
using System.Collections.Generic;

namespace OcenaPracowniczaLys.Data;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = null!;

    public int UserId { get; set; }

    public int Enabled { get; set; }
}
