using System.ComponentModel.DataAnnotations;

namespace RecruitmentSystem.Models
{
    public partial class User
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Role { get; set; } = null!;

        public string? DepartmentId { get; set; }   // Ye zaroori hai!

        public virtual Department? Department { get; set; }
    }

}
