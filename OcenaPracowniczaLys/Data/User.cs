using System;
using System.Collections.Generic;

namespace OcenaPracowniczaLys.Data;

public partial class User
{
    public int UserId { get; set; }

    public string FullName { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool Enabled { get; set; }

    public int RoleId { get; set; }

    public int? ManagerId { get; set; }

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

    public virtual ICollection<Evaluation> Evaluations { get; set; } = new List<Evaluation>();

    public virtual ICollection<User> InverseManager { get; set; } = new List<User>();

    public virtual User? Manager { get; set; }

    public virtual Role Role { get; set; } = null!;
}
