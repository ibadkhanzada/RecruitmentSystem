using Microsoft.EntityFrameworkCore;

namespace RecruitmentSystem.Models
{
    public partial class RecruitmentSystemDbContext : DbContext
    {
        public RecruitmentSystemDbContext(DbContextOptions<RecruitmentSystemDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vacancy> Vacancies { get; set; }
        public virtual DbSet<ApplicantsRequest> ApplicantsRequests { get; set; }
        public virtual DbSet<AddDepartment> AddDepartments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Vacancies table config
            modelBuilder.Entity<Vacancy>(entity =>
            {
                entity.HasKey(e => e.VacancyId);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Description).IsRequired();
                entity.Property(e => e.Location).HasMaxLength(200);
                entity.Property(e => e.EmploymentType).HasMaxLength(100);
                entity.Property(e => e.Salary).HasMaxLength(50);
                entity.Property(e => e.CompanyLogo).HasMaxLength(500);
                entity.Property(e => e.PostedDate).HasColumnType("datetime");
                entity.Property(e => e.ClosingDate).HasColumnType("datetime");
            });
        }
    }
}
