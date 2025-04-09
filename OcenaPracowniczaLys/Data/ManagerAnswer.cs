﻿using System;
using System.Collections.Generic;

namespace OcenaPracowniczaLys.Data;

public partial class ManagerAnswer
{
    public int ManagerAnswerId { get; set; }

    public int EvaluationId { get; set; }

    public int QuestionId { get; set; }

    public string AnswerText { get; set; } = null!;

    public virtual Evaluation Evaluation { get; set; } = null!;

    public virtual Question Question { get; set; } = null!;
}
