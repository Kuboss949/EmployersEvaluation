using System;
using System.Collections.Generic;

namespace OcenaPracowniczaLys.Data;

public partial class Evaluationprodukcjaanswer
{
    public int EvaluationId { get; set; }

    public string Question1 { get; set; } = null!;

    public string Question2 { get; set; } = null!;

    public string Question3 { get; set; } = null!;

    public string Question4 { get; set; } = null!;

    public string Question5 { get; set; } = null!;
}
