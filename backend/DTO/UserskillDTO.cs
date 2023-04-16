using SkillTracker.Entities;

namespace SkillTracker.DTO;

public class UserskillDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int SkillId { get; set; }
    public int Rate { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public UserskillDTO()
    {
        
    }
    
    public UserskillDTO(Userskill userskill)
    {
        Id = userskill.Id;
        UserId = userskill.UserId;
        SkillId = userskill.SkillId;
        Rate = userskill.Rate;
        CreatedAt = userskill.CreatedAt;
    }
    
    public static List<UserskillDTO> FromEntityList(List<Userskill> userskill)
    {
        List<UserskillDTO> skillsDTO = new List<UserskillDTO>(); 
        userskill.ForEach(u => skillsDTO.Add(new UserskillDTO(u)));
        return skillsDTO;
    }

    public Userskill ToEntity()
    {
        return new Userskill
        {
            Id = Id,
            UserId = UserId,
            SkillId = SkillId,
            Rate = Rate,
            CreatedAt = CreatedAt,
        };
    }
}