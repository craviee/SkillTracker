using SkillTracker.Entities;

namespace SkillTracker.DTO;

public class GroupDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public int? UpdatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    
    public GroupDTO()
    {
        
    }
    
    public GroupDTO(Group group)
    {
        Id = group.Id;
        Name = group.Name;
        CreatedAt = group.CreatedAt;
        UpdatedAt = group.UpdatedAt;
        CreatedBy = group.CreatedBy;
        UpdatedBy = group.UpdatedBy;
    }
    
    public static List<GroupDTO> FromEntityList(List<Group> groups)
    {
        List<GroupDTO> groupsDTO = new List<GroupDTO>(); 
        groups.ForEach(u => groupsDTO.Add(new GroupDTO(u)));
        return groupsDTO;
    }

    public Group ToEntity()
    {
        return new Group
        {
            Id = Id,
            Name = Name,
            CreatedAt = CreatedAt,
            UpdatedAt = UpdatedAt,
            CreatedBy = CreatedBy,
            UpdatedBy = UpdatedBy,
        };
    }
}