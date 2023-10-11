using System;
using System.Collections.Generic;

namespace SchoolDummy.Entities;

public partial class Student
{
    public int StudentId { get; set; }

    public string FullName { get; set; } = null!;

    public string? RollNo { get; set; }

    public string? MobileNo { get; set; }

    public string Class { get; set; } = null!;
}
