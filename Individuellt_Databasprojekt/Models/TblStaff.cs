using System;
using System.Collections.Generic;

namespace Individuellt_Databasprojekt.Models;

public partial class TblStaff
{
    public int StaffId { get; set; }

    public string StaffTitle { get; set; } = null!;

    public virtual ICollection<TblAdministrator> TblAdministrators { get; set; } = new List<TblAdministrator>();

    public virtual ICollection<TblJanitor> TblJanitors { get; set; } = new List<TblJanitor>();

    public virtual ICollection<TblPrincipal> TblPrincipals { get; set; } = new List<TblPrincipal>();

    public virtual ICollection<TblTeacher> TblTeachers { get; set; } = new List<TblTeacher>();
}
