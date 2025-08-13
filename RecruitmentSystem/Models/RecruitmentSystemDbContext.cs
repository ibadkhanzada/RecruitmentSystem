using Microsoft.EntityFrameworkCore;

namespace RecruitmentSystem.Models
{
    public partial class RecruitmentSystemDbContext : DbContext
    {
        public RecruitmentSystemDbContext(DbContextOptions<RecruitmentSystemDbContext> options)
            : base(options)
        {
        }

        // --- DbSets ---
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vacancy> Vacancies { get; set; }
        public virtual DbSet<ApplicantsRequest> ApplicantsRequests { get; set; }
        public virtual DbSet<AddDepartment> AddDepartments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // --- Vacancy Table Config ---
            modelBuilder.Entity<Vacancy>(entity =>
            {
                entity.HasKey(e => e.VacancyId);

                entity.Property(e => e.JobTitle)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(e => e.JobDescription)
                      .IsRequired();

                entity.Property(e => e.Status)
                      .HasMaxLength(100);

                entity.Property(e => e.Owner)
                      .HasMaxLength(150);

                entity.Property(e => e.ListOfHired)
                      .HasMaxLength(500);

                entity.Property(e => e.City)
                      .HasMaxLength(150);

                entity.Property(e => e.Country)
                      .HasMaxLength(150);

                entity.Property(e => e.PostedDate)
                      .HasColumnType("datetime");

                entity.Property(e => e.ClosingDate)
                      .HasColumnType("datetime");

                // Foreign Key relation with AddDepartment
                entity.HasOne<AddDepartment>()
                      .WithMany()
                      .HasForeignKey(e => e.DepartmentId)
                      .OnDelete(DeleteBehavior.SetNull);
            });

            // --- User Table Config (optional custom rules) ---
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Name).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Password).IsRequired();
                entity.Property(e => e.Role).IsRequired().HasMaxLength(50);
                entity.Property(e => e.ProfileImagePath).HasMaxLength(500);
            });

            // --- ApplicantsRequest Config ---
            modelBuilder.Entity<ApplicantsRequest>(entity =>
            {
                entity.Property(e => e.FullName).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Phone).IsRequired().HasMaxLength(50);
                entity.Property(e => e.City).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Region).IsRequired().HasMaxLength(150);
                entity.Property(e => e.AreaOfExpertise).IsRequired().HasMaxLength(200);
                entity.Property(e => e.LinkedInProfile).IsRequired().HasMaxLength(500);
                entity.Property(e => e.CvFilePath).HasMaxLength(500);
                entity.Property(e => e.AdditionalComments).HasMaxLength(1000);
            });

            // --- AddDepartment Config ---
            modelBuilder.Entity<AddDepartment>(entity =>
            {
                entity.HasKey(e => e.DepartmentId);
                entity.Property(e => e.DepartmentName).IsRequired().HasMaxLength(200);
            });
        }
    }
}
