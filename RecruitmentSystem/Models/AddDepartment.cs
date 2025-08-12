using System;
using System.Collections.Generic;

namespace RecruitmentSystem.Models;

public partial class AddDepartment
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = null!;

    public virtual ICollection<Vacancy> Vacancies { get; set; } = new List<Vacancy>();
}
