using System;
using System.Collections.Generic;

namespace SkillTracker.Entities;

public partial class Skill
{
    public int Id { get; set; }

    public int GroupId { get; set; }

    public string Name { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual Group Group { get; set; } = null!;

    public virtual User? UpdatedByNavigation { get; set; }

    public virtual ICollection<Userskill> Userskills { get; set; } = new List<Userskill>();
}
