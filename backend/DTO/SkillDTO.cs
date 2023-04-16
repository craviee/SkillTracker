using SkillTracker.Entities;

namespace SkillTracker.DTO;

public class SkillDTO
{
    public int Id { get; set; }
    public int GroupId { get; set; }
    public string Name { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public int? UpdatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    
    public SkillDTO()
    {
        
    }
    
    public SkillDTO(Skill skill)
    {
        Id = skill.Id;
        GroupId = skill.GroupId;
        Name = skill.Name;
        CreatedAt = skill.CreatedAt;
        UpdatedAt = skill.UpdatedAt;
        CreatedBy = skill.CreatedBy;
        UpdatedBy = skill.UpdatedBy;
    }
    
    public static List<SkillDTO> FromEntityList(List<Skill> skills)
    {
        List<SkillDTO> skillsDTO = new List<SkillDTO>(); 
        skills.ForEach(u => skillsDTO.Add(new SkillDTO(u)));
        return skillsDTO;
    }

    public Skill ToEntity()
    {
        return new Skill
        {
            Id = Id,
            GroupId = GroupId,
            Name = Name,
            CreatedAt = CreatedAt,
            UpdatedAt = UpdatedAt,
            CreatedBy = CreatedBy,
            UpdatedBy = UpdatedBy,
        };
    }
}