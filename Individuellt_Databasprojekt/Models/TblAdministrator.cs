using System;
using System.Collections.Generic;

namespace Individuellt_Databasprojekt.Models;

public partial class TblAdministrator
{
    public int AdminId { get; set; }

    public string AdminFname { get; set; } = null!;

    public string AdminLname { get; set; } = null!;

    public int StaffId { get; set; }

    public decimal Salary { get; set; }

    public DateOnly DateOfEmployment { get; set; }

    public virtual TblStaff Staff { get; set; } = null!;
}
