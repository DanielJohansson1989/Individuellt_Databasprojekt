using System;
using System.Collections.Generic;

namespace Individuellt_Databasprojekt.Models;

public partial class TblStudent
{
    public int StudentId { get; set; }

    public string PersonalNumber { get; set; } = null!;

    public string StudentFname { get; set; } = null!;

    public string StudentLname { get; set; } = null!;

    public int ClassId { get; set; }

    public virtual TblClass Class { get; set; } = null!;

    public virtual ICollection<TblCourse> TblCourses { get; set; } = new List<TblCourse>();
}
