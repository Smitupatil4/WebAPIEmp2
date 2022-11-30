using System;
using System.Collections.Generic;

namespace WebAPIEmp2.Models;

public partial class EmpPersonalInfo
{
    public int EmpId { get; set; }

    public string Fname { get; set; } = null!;

    public string Lname { get; set; } = null!;

    public int MobNumber { get; set; }
}
