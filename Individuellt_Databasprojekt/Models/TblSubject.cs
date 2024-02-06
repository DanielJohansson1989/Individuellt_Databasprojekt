using System;
using System.Collections.Generic;

namespace Individuellt_Databasprojekt.Models;

public partial class TblSubject
{
    public int SubjectId { get; set; }

    public string SubjectName { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public virtual ICollection<TblCourse> TblCourses { get; set; } = new List<TblCourse>();
}
