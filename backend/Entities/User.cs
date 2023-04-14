using System;
using System.Collections.Generic;

namespace SkillTracker.Entities;

public partial class User
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public string Email { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int Role { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsEnabled { get; set; }

    public virtual ICollection<Group> GroupCreatedByNavigations { get; set; } = new List<Group>();

    public virtual ICollection<Group> GroupUpdatedByNavigations { get; set; } = new List<Group>();

    public virtual ICollection<Skill> SkillCreatedByNavigations { get; set; } = new List<Skill>();

    public virtual ICollection<Skill> SkillUpdatedByNavigations { get; set; } = new List<Skill>();

    public virtual ICollection<Userskill> Userskills { get; set; } = new List<Userskill>();
}
