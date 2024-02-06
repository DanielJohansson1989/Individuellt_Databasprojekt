using System;
using System.Collections.Generic;

namespace Individuellt_Databasprojekt.Models;

public partial class TblGrade
{
    public int GradeId { get; set; }

    public string? GradeSymbol { get; set; }

    public virtual ICollection<TblCourse> TblCourses { get; set; } = new List<TblCourse>();
}
