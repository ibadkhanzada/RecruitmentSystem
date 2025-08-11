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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Users table config
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Password).IsRequired();
            });

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
            });

            // ApplicantsRequests table config
            modelBuilder.Entity<ApplicantsRequest>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FullName).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Phone).IsRequired().HasMaxLength(50);
                entity.Property(e => e.City).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Region).IsRequired().HasMaxLength(100);
                entity.Property(e => e.AreaOfExpertise).IsRequired().HasMaxLength(200);
                entity.Property(e => e.YearsOfExperience).IsRequired();
                entity.Property(e => e.CvFilePath).HasMaxLength(500);
                entity.Property(e => e.LinkedInProfile).IsRequired().HasMaxLength(300);
                entity.Property(e => e.AdditionalComments).HasMaxLength(1000);
            });
        }
    }
}
