using System;
using System.Collections.Generic;

namespace SchoolDummy.Entities;

public partial class Teacher
{
    public int TeacherId { get; set; }

    public string Name { get; set; } = null!;

    public string? Qualification { get; set; }

    public string? MobileNo { get; set; }
}
