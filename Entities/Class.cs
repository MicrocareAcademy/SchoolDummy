﻿using System;
using System.Collections.Generic;

namespace SchoolDummy.Entities;

public partial class Class
{
    public int ClassId { get; set; }

    public string Title { get; set; } = null!;

    public string? InchargePerson { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
