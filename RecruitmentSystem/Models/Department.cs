// Department.cs
namespace RecruitmentSystem.Models
{
    public partial class Department
    {
        public string DepartmentId { get; set; } = null!;

        public string DepartmentName { get; set; } = null!;

        // Remove this navigation property
        // public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
