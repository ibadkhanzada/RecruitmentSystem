using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RecruitmentSystem.Models;

public partial class HrdataContext : DbContext
{
    public HrdataContext()
    {
    }

    public HrdataContext(DbContextOptions<HrdataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AddDepartment> AddDepartments { get; set; }

    public virtual DbSet<Vacancy> Vacancies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=DESKTOP-AAQDGFN\\SQLEXPRESS;initial catalog=Hrdata;user id=sa;password=aptech; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AddDepartment>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__AddDepar__B2079BCD60406A74");

            entity.HasIndex(e => e.DepartmentName, "UQ__AddDepar__D949CC347BD3ECED").IsUnique();

            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.DepartmentName).HasMaxLength(100);
        });

        modelBuilder.Entity<Vacancy>(entity =>
        {
            entity.HasKey(e => e.VacancyId).HasName("PK__Vacancie__6456765F1DC450C5");

            entity.Property(e => e.VacancyId).HasColumnName("VacancyID");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.JobTitle)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ListOfHired).HasMaxLength(50);
            entity.Property(e => e.Owner)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PostedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Department).WithMany(p => p.Vacancies)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vacancies_AddDepartment");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
