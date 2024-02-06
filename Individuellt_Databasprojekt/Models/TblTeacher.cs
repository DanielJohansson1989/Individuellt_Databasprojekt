using System;
using System.Collections.Generic;

namespace Individuellt_Databasprojekt.Models;

public partial class TblTeacher
{
    public int TeacherId { get; set; }

    public string TeacherFname { get; set; } = null!;

    public string TeacherLname { get; set; } = null!;

    public int StaffId { get; set; }

    public int DepartmentId { get; set; }

    public decimal Salary { get; set; }

    public DateOnly DateOfEmployment { get; set; }

    public virtual TblDepartment Department { get; set; } = null!;

    public virtual TblStaff Staff { get; set; } = null!;

    public virtual ICollection<TblCourse> TblCourses { get; set; } = new List<TblCourse>();
}
