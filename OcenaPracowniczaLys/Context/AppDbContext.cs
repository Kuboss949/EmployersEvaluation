using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OcenaPracowniczaLys.Data;

namespace OcenaPracowniczaLys.Context;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<EmployeeAnswer> EmployeeAnswers { get; set; }

    public virtual DbSet<Evaluation> Evaluations { get; set; }

    public virtual DbSet<MainDepartment> MainDepartments { get; set; }

    public virtual DbSet<ManagerAnswer> ManagerAnswers { get; set; }

    public virtual DbSet<ManagerAnswersText> ManagerAnswersTexts { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=ocena_lepsza;User Id=sa;Password=test123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__C223242262D06871");

            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.Enabled)
                .HasDefaultValue(true)
                .HasColumnName("enabled");
            entity.Property(e => e.ManagerId).HasColumnName("manager_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");

            entity.HasOne(d => d.Manager).WithMany(p => p.Departments)
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("FK_Departments_Manager");
        });

        modelBuilder.Entity<EmployeeAnswer>(entity =>
        {
            entity.HasKey(e => e.EmployeeAnswerId).HasName("PK__Employee__9278760EC47AB220");

            entity.Property(e => e.EmployeeAnswerId).HasColumnName("employee_answer_id");
            entity.Property(e => e.AnswerText).HasColumnName("answer_text");
            entity.Property(e => e.EvaluationId).HasColumnName("evaluation_id");
            entity.Property(e => e.QuestionId).HasColumnName("question_id");

            entity.HasOne(d => d.Evaluation).WithMany(p => p.EmployeeAnswers)
                .HasForeignKey(d => d.EvaluationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeAnswers_Evaluations");

            entity.HasOne(d => d.Question).WithMany(p => p.EmployeeAnswers)
                .HasForeignKey(d => d.QuestionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeAnswers_Questions");
        });

        modelBuilder.Entity<Evaluation>(entity =>
        {
            entity.HasKey(e => e.EvaluationId).HasName("PK__Evaluati__827C592DAFB9AC71");

            entity.Property(e => e.EvaluationId).HasColumnName("evaluation_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(100)
                .HasColumnName("employee_name");
            entity.Property(e => e.EmployeePosition)
                .HasMaxLength(100)
                .HasColumnName("employee_position");
            entity.Property(e => e.MainDepartmentId).HasColumnName("main_department_id");
            entity.Property(e => e.ManagerAnswerId).HasColumnName("manager_answer_id");
            entity.Property(e => e.ManagerId).HasColumnName("manager_id");

            entity.HasOne(d => d.Department).WithMany(p => p.Evaluations)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Evaluations_Department");

            entity.HasOne(d => d.MainDepartment).WithMany(p => p.Evaluations)
                .HasForeignKey(d => d.MainDepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Evaluations_MainDepartment");

            entity.HasOne(d => d.Manager).WithMany(p => p.Evaluations)
                .HasForeignKey(d => d.ManagerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Evaluations_Manager");
        });

        modelBuilder.Entity<MainDepartment>(entity =>
        {
            entity.HasKey(e => e.MainDepartmentId).HasName("PK__MainDepa__F1F83E9A5CDEA549");

            entity.Property(e => e.MainDepartmentId).HasColumnName("main_department_id");
            entity.Property(e => e.Enabled)
                .HasDefaultValue(true)
                .HasColumnName("enabled");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<ManagerAnswer>(entity =>
        {
            entity.HasKey(e => e.ManagerAnswerId).HasName("PK__ManagerA__5B94A64B710564FF");

            entity.HasIndex(e => e.EvaluationId, "UQ_ManagerAnswer_Evaluation").IsUnique();

            entity.Property(e => e.ManagerAnswerId).HasColumnName("manager_answer_id");
            entity.Property(e => e.EvaluationId).HasColumnName("evaluation_id");

            entity.HasOne(d => d.Evaluation).WithOne(p => p.ManagerAnswer)
                .HasForeignKey<ManagerAnswer>(d => d.EvaluationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ManagerAnswers_Evaluations");
        });

        modelBuilder.Entity<ManagerAnswersText>(entity =>
        {
            entity.HasKey(e => e.ManagerAnswerTextId);

            entity.ToTable("ManagerAnswersText");

            entity.Property(e => e.ManagerAnswerTextId).HasColumnName("manager_answer_text_id");
            entity.Property(e => e.AnswerText).HasColumnName("answer_text");
            entity.Property(e => e.ManagerAnswerId).HasColumnName("manager_answer_id");
            entity.Property(e => e.QuestionId).HasColumnName("question_id");

            entity.HasOne(d => d.ManagerAnswer).WithMany(p => p.ManagerAnswersTexts)
                .HasForeignKey(d => d.ManagerAnswerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ManagerAnswersText_ManagerAnswers");

            entity.HasOne(d => d.Question).WithMany(p => p.ManagerAnswersTexts)
                .HasForeignKey(d => d.QuestionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ManagerAnswersText_Questions");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.QuestionId).HasName("PK__Question__2EC21549D04AD0B0");

            entity.Property(e => e.QuestionId).HasColumnName("question_id");
            entity.Property(e => e.Enabled)
                .HasDefaultValue(true)
                .HasColumnName("enabled");
            entity.Property(e => e.MainDepartmentId).HasColumnName("main_department_id");
            entity.Property(e => e.Priority)
                .HasDefaultValue(100)
                .HasColumnName("priority");
            entity.Property(e => e.QuestionText)
                .HasMaxLength(1000)
                .HasColumnName("question_text");

            entity.HasOne(d => d.MainDepartment).WithMany(p => p.Questions)
                .HasForeignKey(d => d.MainDepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Questions_MainDepartments");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__760965CC9CB6076A");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__B9BE370F266A9E10");

            entity.HasIndex(e => e.Login, "UQ__Users__7838F272CCE74EC8").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Enabled)
                .HasDefaultValue(true)
                .HasColumnName("enabled");
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .HasColumnName("full_name");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .HasColumnName("login");
            entity.Property(e => e.ManagerId).HasColumnName("manager_id");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.HasOne(d => d.Manager).WithMany(p => p.InverseManager)
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("FK_Users_Manager");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
