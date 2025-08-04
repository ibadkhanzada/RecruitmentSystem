using System;
using System.Collections.Generic;

namespace RecruitmentSystem.Models;

public partial class Department
{
    public string DepartmentId { get; set; } = null!;

    public string DepartmentName { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();

    public virtual ICollection<Vacancy> Vacancies { get; set; } = new List<Vacancy>();
}
