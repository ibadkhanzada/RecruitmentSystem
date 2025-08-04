using System;
using System.Collections.Generic;

namespace RecruitmentSystem.Models;

public partial class Vacancy
{
    public string VacancyId { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public int Openings { get; set; }

    public string Status { get; set; } = null!;

    public string DepartmentId { get; set; } = null!;

    public int OwnerId { get; set; }

    public DateOnly CreatedDate { get; set; }

    public DateOnly? CloseDate { get; set; }

    public virtual ICollection<ApplicantVacancy> ApplicantVacancies { get; set; } = new List<ApplicantVacancy>();

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<Interview> Interviews { get; set; } = new List<Interview>();

    public virtual User Owner { get; set; } = null!;
}
