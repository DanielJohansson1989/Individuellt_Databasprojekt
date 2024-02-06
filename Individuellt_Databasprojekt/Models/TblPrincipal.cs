using System;
using System.Collections.Generic;

namespace Individuellt_Databasprojekt.Models;

public partial class TblPrincipal
{
    public int PrincipalId { get; set; }

    public string PrincipalFname { get; set; } = null!;

    public string PrincipalLname { get; set; } = null!;

    public int StaffId { get; set; }

    public decimal Salary { get; set; }

    public DateOnly DateOfEmployment { get; set; }

    public virtual TblStaff Staff { get; set; } = null!;
}
