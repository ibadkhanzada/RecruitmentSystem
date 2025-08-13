namespace RecruitmentSystem.Models
{
    public class Vacancy
    {
        public int VacancyId { get; set; }

        // Title
        public string JobTitle { get; set; } = null!;

        // Description
        public string JobDescription { get; set; } = null!;

        // Date when the job was created
        public DateTime? PostedDate { get; set; }

        // Department
        public int? DepartmentId { get; set; }

        // Status
        public string? Status { get; set; }

        // No. of Openings
        public int? NoOfOpening { get; set; }

        // Owner
        public string? Owner { get; set; }

        // Close Date
        public DateTime? ClosingDate { get; set; }

        // List of hired applicants
        public string? ListOfHired { get; set; }

        // City
        public string? City { get; set; }

        // Country
        public string? Country { get; set; }
    }
}
