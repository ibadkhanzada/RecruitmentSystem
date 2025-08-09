using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RecruitmentSystem.Models
{
    public partial class RecruitmentSystemDbContext : DbContext
    {
        public RecruitmentSystemDbContext()
        {
        }

        public RecruitmentSystemDbContext(DbContextOptions<RecruitmentSystemDbContext> options)
            : base(options)
        {
        }

        // Departments table abhi rakh sakte ho, ya hata bhi sakte ho agar ab use nahi karna
        public virtual DbSet<Department> Departments { get; set; }

        // Users table with no DepartmentId FK
        public virtual DbSet<User> Users { get; set; }

        public DbSet<ApplicantsRequest> ApplicantsRequests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning Move your connection string out of source code for security
            => optionsBuilder.UseSqlServer("Server=.;Database=RecruitmentSystem_db;Trusted_Connection=True;TrustServerCertificate=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BED3873E238");

                entity.Property(e => e.DepartmentId).HasMaxLength(10);
                entity.Property(e => e.DepartmentName).HasMaxLength(100);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Users__3214EC0794F0B1E2");

                entity.HasIndex(e => e.Email).IsUnique();

                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.Password).HasMaxLength(100);
                entity.Property(e => e.Role).HasMaxLength(20);

                // **DepartmentId and FK removed here**
                // entity.Property(e => e.DepartmentId).HasMaxLength(10);
                // entity.HasOne(d => d.Department).WithMany(p => p.Users)
                //     .HasForeignKey(d => d.DepartmentId)
                //     .HasConstraintName("FK__Users__Departmen__276EDEB3");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
