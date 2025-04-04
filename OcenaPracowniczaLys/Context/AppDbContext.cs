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

    public virtual DbSet<Evaluationbiuro> Evaluationbiuros { get; set; }

    public virtual DbSet<Evaluationbiuroanswer> Evaluationbiuroanswers { get; set; }

    public virtual DbSet<Evaluationname> Evaluationnames { get; set; }

    public virtual DbSet<Evaluationprodukcjaanswer> Evaluationprodukcjaanswers { get; set; }

    public virtual DbSet<Evaluationsprodukcja> Evaluationsprodukcjas { get; set; }

    public virtual DbSet<Globalsetting> Globalsettings { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=ocena_pracownicza;User Id=sa;Password=test123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__departme__B2079BCD09D70254");

            entity.ToTable("department");

            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.DepartmentName).IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<Evaluationbiuro>(entity =>
        {
            entity.HasKey(e => e.EvaluationId)
                .HasName("PK__evaluati__36AE68D384D55F66")
                .HasFillFactor(1);

            entity.ToTable("evaluationbiuro");

            entity.Property(e => e.EvaluationId).HasColumnName("EvaluationID");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.EvaluationAnswerId).HasColumnName("EvaluationAnswerID");
            entity.Property(e => e.EvaluatorNameId).HasColumnName("EvaluatorNameID");
            entity.Property(e => e.Question1).IsUnicode(false);
            entity.Property(e => e.Question10).IsUnicode(false);
            entity.Property(e => e.Question11).IsUnicode(false);
            entity.Property(e => e.Question2).IsUnicode(false);
            entity.Property(e => e.Question3).IsUnicode(false);
            entity.Property(e => e.Question4).IsUnicode(false);
            entity.Property(e => e.Question5).IsUnicode(false);
            entity.Property(e => e.Question6).IsUnicode(false);
            entity.Property(e => e.Question7).IsUnicode(false);
            entity.Property(e => e.Question8).IsUnicode(false);
            entity.Property(e => e.Question9).IsUnicode(false);
            entity.Property(e => e.Stanowisko).IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.UserName).IsUnicode(false);
        });

        modelBuilder.Entity<Evaluationbiuroanswer>(entity =>
        {
            entity.HasKey(e => e.EvaluationId).HasName("PK__evaluati__36AE68D31E8108F0");

            entity.ToTable("evaluationbiuroanswers");

            entity.Property(e => e.EvaluationId).HasColumnName("EvaluationID");
            entity.Property(e => e.Question1).IsUnicode(false);
            entity.Property(e => e.Question10).IsUnicode(false);
            entity.Property(e => e.Question11).IsUnicode(false);
            entity.Property(e => e.Question2).IsUnicode(false);
            entity.Property(e => e.Question3).IsUnicode(false);
            entity.Property(e => e.Question4).IsUnicode(false);
            entity.Property(e => e.Question5).IsUnicode(false);
            entity.Property(e => e.Question6).IsUnicode(false);
            entity.Property(e => e.Question7).IsUnicode(false);
            entity.Property(e => e.Question8).IsUnicode(false);
            entity.Property(e => e.Question9).IsUnicode(false);
        });

        modelBuilder.Entity<Evaluationname>(entity =>
        {
            entity.HasKey(e => e.EvaluatorNameId).HasName("PK__evaluati__0892287A98BA4AF3");

            entity.ToTable("evaluationnames");

            entity.Property(e => e.EvaluatorNameId).HasColumnName("EvaluatorNameID");
            entity.Property(e => e.EvaluatorName).IsUnicode(false);
        });

        modelBuilder.Entity<Evaluationprodukcjaanswer>(entity =>
        {
            entity.HasKey(e => e.EvaluationId).HasName("PK__evaluati__36AE68D325F5EC39");

            entity.ToTable("evaluationprodukcjaanswers");

            entity.Property(e => e.EvaluationId).HasColumnName("EvaluationID");
            entity.Property(e => e.Question1).IsUnicode(false);
            entity.Property(e => e.Question2).IsUnicode(false);
            entity.Property(e => e.Question3).IsUnicode(false);
            entity.Property(e => e.Question4).IsUnicode(false);
            entity.Property(e => e.Question5).IsUnicode(false);
        });

        modelBuilder.Entity<Evaluationsprodukcja>(entity =>
        {
            entity.HasKey(e => e.EvaluationId).HasName("PK__evaluati__36AE68D31B5E548B");

            entity.ToTable("evaluationsprodukcja");

            entity.Property(e => e.EvaluationId).HasColumnName("EvaluationID");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.EvaluationAnswerId).HasColumnName("EvaluationAnswerID");
            entity.Property(e => e.EvaluatorNameId).HasColumnName("EvaluatorNameID");
            entity.Property(e => e.Question1).IsUnicode(false);
            entity.Property(e => e.Question2).IsUnicode(false);
            entity.Property(e => e.Question3).IsUnicode(false);
            entity.Property(e => e.Question4).IsUnicode(false);
            entity.Property(e => e.Question5).IsUnicode(false);
            entity.Property(e => e.Stanowisko).IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.UserName).IsUnicode(false);
        });

        modelBuilder.Entity<Globalsetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__globalse__3214EC07F78B72CF");

            entity.ToTable("globalsettings");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CurrentEvaluationName).IsUnicode(false);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("roles");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.RoleName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__users__1788CCAC279B5EBA");

            entity.ToTable("users");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.FullName).IsUnicode(false);
            entity.Property(e => e.Login).IsUnicode(false);
            entity.Property(e => e.ManagerId).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Password).IsUnicode(false);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_users_roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
