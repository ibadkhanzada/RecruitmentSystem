using System;
using System.Collections.Generic;

namespace RecruitmentSystem.Models;

public partial class Applicant
{
    public string ApplicantId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateOnly CreatedDate { get; set; }

    public virtual ICollection<ApplicantVacancy> ApplicantVacancies { get; set; } = new List<ApplicantVacancy>();

    public virtual ICollection<Interview> Interviews { get; set; } = new List<Interview>();
}
