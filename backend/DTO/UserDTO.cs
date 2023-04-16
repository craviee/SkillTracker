using Microsoft.AspNetCore.Mvc;
using SkillTracker.Entities;

namespace SkillTracker.DTO;

public class UserDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string Email { get; set; }
    public int Role { get; set; }
    public bool IsEnabled { get; set; }

    public UserDTO()
    {
        
    }
    
    public UserDTO(User user)
    {
        Id = user.Id;
        Name = user.Name;
        CreatedAt = user.CreatedAt;
        UpdatedAt = user.UpdatedAt;
        Email = user.Email;
        Role = user.Role;
        IsEnabled = user.IsEnabled;
    }
    
    public static List<UserDTO> FromEntityList(List<User> users)
    {
        List<UserDTO> usersDTO = new List<UserDTO>(); 
        users.ForEach(u => usersDTO.Add(new UserDTO(u)));
        return usersDTO;
    }

    public User ToEntity()
    {
        return new User
        {
            Id = Id,
            CreatedAt = CreatedAt,
            Email = Email,
            Name = Name,
            Role = Role,
            UpdatedAt = UpdatedAt,
            IsEnabled = IsEnabled
        };
    }
}