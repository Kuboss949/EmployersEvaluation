using System;
using System.Collections.Generic;

namespace OcenaPracowniczaLys.Data;

public partial class ManagerAnswersText
{
    public int ManagerAnswerTextId { get; set; }

    public int ManagerAnswerId { get; set; }

    public int QuestionId { get; set; }

    public string? AnswerText { get; set; }

    public virtual ManagerAnswer ManagerAnswer { get; set; } = null!;

    public virtual Question Question { get; set; } = null!;
}
