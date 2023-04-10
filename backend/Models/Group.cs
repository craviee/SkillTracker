namespace SkillTracker.Models;

public class Group
{
    public decimal Id { get; set; }
    public string Name { get; set; }
    public decimal CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public decimal? UpdatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
}