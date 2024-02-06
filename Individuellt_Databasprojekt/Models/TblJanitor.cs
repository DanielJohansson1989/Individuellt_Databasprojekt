using System;
using System.Collections.Generic;

namespace Individuellt_Databasprojekt.Models;

public partial class TblJanitor
{
    public int JanitorId { get; set; }

    public string JanitorFname { get; set; } = null!;

    public string JanitorLname { get; set; } = null!;

    public int StaffId { get; set; }

    public decimal Salary { get; set; }

    public DateOnly DateOfEmployment { get; set; }

    public virtual TblStaff Staff { get; set; } = null!;
}
