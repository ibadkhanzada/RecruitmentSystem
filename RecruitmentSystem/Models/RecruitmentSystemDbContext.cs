using Microsoft.EntityFrameworkCore;
using RecruitmentSystem.Models;

namespace RecruitmentSystem.Models
{
    public partial class RecruitmentSystemDbContext : DbContext
    {
        public RecruitmentSystemDbContext(DbContextOptions<RecruitmentSystemDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<ApplicantsRequest> ApplicantsRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DepartmentId);

                entity.Property(e => e.DepartmentId).HasMaxLength(10);
                entity.Property(e => e.DepartmentName).HasMaxLength(100);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasIndex(e => e.Email).IsUnique();

                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.Password).HasMaxLength(100);
                entity.Property(e => e.Role).HasMaxLength(20);

                // No relation or foreign key to Department here
            });

            // Configure ApplicantsRequest if needed

            base.OnModelCreating(modelBuilder);
        }
    }
}
