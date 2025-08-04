using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RecruitmentSystem.Models;

public partial class RecruitmentSystemDbContext : DbContext
{
    public RecruitmentSystemDbContext()
    {
    }

    public RecruitmentSystemDbContext(DbContextOptions<RecruitmentSystemDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Applicant> Applicants { get; set; }

    public virtual DbSet<ApplicantVacancy> ApplicantVacancies { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Interview> Interviews { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vacancy> Vacancies { get; set; }

    public DbSet<ApplicantsRequest> ApplicantsRequests { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=RecruitmentSystem_db;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Applicant>(entity =>
        {
            entity.HasKey(e => e.ApplicantId).HasName("PK__Applican__39AE91A8F3B99E3A");

            entity.HasIndex(e => e.Email, "UQ__Applican__A9D1053464909E87").IsUnique();

            entity.Property(e => e.ApplicantId).HasMaxLength(10);
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Status).HasMaxLength(20);
        });

        modelBuilder.Entity<ApplicantVacancy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Applican__3214EC07BE91301B");

            entity.ToTable("ApplicantVacancy");

            entity.Property(e => e.ApplicantId).HasMaxLength(10);
            entity.Property(e => e.ApplicationStatus).HasMaxLength(30);
            entity.Property(e => e.AttachedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.VacancyId).HasMaxLength(10);

            entity.HasOne(d => d.Applicant).WithMany(p => p.ApplicantVacancies)
                .HasForeignKey(d => d.ApplicantId)
                .HasConstraintName("FK__Applicant__Appli__34C8D9D1");

            entity.HasOne(d => d.Vacancy).WithMany(p => p.ApplicantVacancies)
                .HasForeignKey(d => d.VacancyId)
                .HasConstraintName("FK__Applicant__Vacan__35BCFE0A");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BED3873E238");

            entity.Property(e => e.DepartmentId).HasMaxLength(10);
            entity.Property(e => e.DepartmentName).HasMaxLength(100);
        });

        modelBuilder.Entity<Interview>(entity =>
        {
            entity.HasKey(e => e.InterviewId).HasName("PK__Intervie__C97C58523CDA2172");

            entity.Property(e => e.ApplicantId).HasMaxLength(10);
            entity.Property(e => e.Result).HasMaxLength(20);
            entity.Property(e => e.VacancyId).HasMaxLength(10);

            entity.HasOne(d => d.Applicant).WithMany(p => p.Interviews)
                .HasForeignKey(d => d.ApplicantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Interview__Appli__398D8EEE");

            entity.HasOne(d => d.Interviewer).WithMany(p => p.Interviews)
                .HasForeignKey(d => d.InterviewerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Interview__Inter__38996AB5");

            entity.HasOne(d => d.Vacancy).WithMany(p => p.Interviews)
                .HasForeignKey(d => d.VacancyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Interview__Vacan__3A81B327");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC0794F0B1E2");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534A15B0BD8").IsUnique();

            entity.Property(e => e.DepartmentId).HasMaxLength(10);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Role).HasMaxLength(20);

            entity.HasOne(d => d.Department).WithMany(p => p.Users)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__Users__Departmen__276EDEB3");
        });

        modelBuilder.Entity<Vacancy>(entity =>
        {
            entity.HasKey(e => e.VacancyId).HasName("PK__Vacancie__6456763F9EC927CD");

            entity.Property(e => e.VacancyId).HasMaxLength(10);
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DepartmentId).HasMaxLength(10);
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.Title).HasMaxLength(100);

            entity.HasOne(d => d.Department).WithMany(p => p.Vacancies)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Vacancies__Depar__2B3F6F97");

            entity.HasOne(d => d.Owner).WithMany(p => p.Vacancies)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Vacancies__Owner__2C3393D0");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
