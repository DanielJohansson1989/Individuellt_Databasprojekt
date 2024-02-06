using System;
using System.Collections.Generic;

namespace Individuellt_Databasprojekt.Models;

public partial class TblClass
{
    public int ClassId { get; set; }

    public string? ClassName { get; set; }

    public virtual ICollection<TblStudent> TblStudents { get; set; } = new List<TblStudent>();
}
