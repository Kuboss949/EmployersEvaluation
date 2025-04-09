using System;
using System.Collections.Generic;

namespace OcenaPracowniczaLys.Data;

public partial class Question
{
    public int QuestionId { get; set; }

    public int MainDepartmentId { get; set; }

    public string QuestionText { get; set; } = null!;

    public virtual ICollection<EmployeeAnswer> EmployeeAnswers { get; set; } = new List<EmployeeAnswer>();

    public virtual MainDepartment MainDepartment { get; set; } = null!;

    public virtual ICollection<ManagerAnswer> ManagerAnswers { get; set; } = new List<ManagerAnswer>();
}
