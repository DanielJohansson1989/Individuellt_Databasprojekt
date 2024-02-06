using System;
using System.Collections.Generic;

namespace Individuellt_Databasprojekt.Models;

public partial class TblCourse
{
    public int CourseId { get; set; }

    public int StudentId { get; set; }

    public int SubjectId { get; set; }

    public int? GradeId { get; set; }

    public DateOnly? GradeDate { get; set; }

    public int? TeacherId { get; set; }

    public virtual TblGrade? Grade { get; set; }

    public virtual TblStudent Student { get; set; } = null!;

    public virtual TblSubject Subject { get; set; } = null!;

    public virtual TblTeacher? Teacher { get; set; }
}
