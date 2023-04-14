namespace SkillTracker.DTO;

public class UserDTO
{
    public decimal Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string Email { get; set; }
    public int Role { get; set; }
    public bool IsEnabled { get; set; }
}