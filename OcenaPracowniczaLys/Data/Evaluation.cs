using System;
using System.Collections.Generic;

namespace OcenaPracowniczaLys.Data;

public partial class Evaluation
{
    public int EvaluationId { get; set; }

    public string EmployeeName { get; set; } = null!;

    public string? EmployeePosition { get; set; }

    public int DepartmentId { get; set; }

    public int ManagerId { get; set; }

    public int MainDepartmentId { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<EmployeeAnswer> EmployeeAnswers { get; set; } = new List<EmployeeAnswer>();

    public virtual MainDepartment MainDepartment { get; set; } = null!;

    public virtual User Manager { get; set; } = null!;

    public virtual ICollection<ManagerAnswer> ManagerAnswers { get; set; } = new List<ManagerAnswer>();
}
