using System;
using System.Collections.Generic;

namespace RecruitmentSystem.Models;

public partial class ApplicantVacancy
{
    public int Id { get; set; }

    public string? ApplicantId { get; set; }

    public string? VacancyId { get; set; }

    public DateOnly AttachedDate { get; set; }

    public string ApplicationStatus { get; set; } = null!;

    public bool ScheduleInterview { get; set; }

    public virtual Applicant? Applicant { get; set; }

    public virtual Vacancy? Vacancy { get; set; }
}
