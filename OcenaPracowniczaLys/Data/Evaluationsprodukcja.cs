using System;
using System.Collections.Generic;

namespace OcenaPracowniczaLys.Data;

public partial class Evaluationsprodukcja
{
    public int EvaluationId { get; set; }

    public string UserName { get; set; } = null!;

    public int UserId { get; set; }

    public int EvaluatorNameId { get; set; }

    public DateTime Date { get; set; }

    public string Question1 { get; set; } = null!;

    public string Question2 { get; set; } = null!;

    public string Question3 { get; set; } = null!;

    public string Question4 { get; set; } = null!;

    public int EvaluationAnswerId { get; set; }

    public string Question5 { get; set; } = null!;

    public int DepartmentId { get; set; }

    public string Stanowisko { get; set; } = null!;
}
