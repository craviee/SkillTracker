﻿using System;
using System.Collections.Generic;

namespace SkillTracker.Entities;

public partial class Group
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();

    public virtual User UpdatedByNavigation { get; set; } = null!;
}
