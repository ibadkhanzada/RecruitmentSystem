using System;
using System.Collections.Generic;

namespace RecruitmentSystem.Models;

public partial class Interview
{
    public int InterviewId { get; set; }

    public int InterviewerId { get; set; }

    public string ApplicantId { get; set; } = null!;

    public string VacancyId { get; set; } = null!;

    public DateOnly InterviewDate { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public string? Result { get; set; }

    public virtual Applicant Applicant { get; set; } = null!;

    public virtual User Interviewer { get; set; } = null!;

    public virtual Vacancy Vacancy { get; set; } = null!;
}
