using System;
using System.Collections.Generic;

namespace RecruitmentSystem.Models;

public partial class Vacancy
{
    public int VacancyId { get; set; }

    public string JobTitle { get; set; } = null!;

    public int DepartmentId { get; set; }

    public string Country { get; set; } = null!;

    public string City { get; set; } = null!;

    public string? JobDescription { get; set; }

    public string ListOfHired { get; set; } = null!;

    public string Owner { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateOnly PostedDate { get; set; }

    public DateOnly? ClosingDate { get; set; }

    public virtual AddDepartment Department { get; set; } = null!;
}
