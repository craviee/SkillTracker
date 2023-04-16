using System;
using System.Collections.Generic;

namespace SkillTracker.Entities;

public partial class Userskill
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int SkillId { get; set; }

    public int Rate { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Skill Skill { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
