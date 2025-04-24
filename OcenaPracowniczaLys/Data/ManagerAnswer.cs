using System;
using System.Collections.Generic;

namespace OcenaPracowniczaLys.Data;

public partial class ManagerAnswer
{
    public int ManagerAnswerId { get; set; }

    public int EvaluationId { get; set; }

    public virtual Evaluation Evaluation { get; set; } = null!;

    public virtual ICollection<ManagerAnswersText> ManagerAnswersTexts { get; set; } = new List<ManagerAnswersText>();
}
