namespace SkillTracker.DTO;

public class UserSkillDTO
{
    public decimal Id { get; set; }
    public decimal UserId { get; set; }
    public decimal SkillId { get; set; }
    public int Rate { get; set; }
    public DateTime CreatedAt { get; set; }
}