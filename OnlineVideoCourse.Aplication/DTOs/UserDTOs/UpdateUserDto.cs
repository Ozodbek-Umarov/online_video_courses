using OnlineVideoCourses.Domain.Entities;
using OnlineVideoCourses.Domain.Enums;

namespace OnlineVideoCourse.Aplication.DTOs.UserDTOs;

public class UpdateUserDto
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";
    public bool IsVerified { get; set; } = false;
    public Gender Gender { get; set; }
    public string Password { get; set; } = "";
    public Role Role { get; set; } = Role.User;

    public static implicit operator User(UpdateUserDto dto)
    {
        return new User
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            IsVerified = dto.IsVerified,
            Gender = dto.Gender,
            Password = dto.Password,
            Role = dto.Role
        };
    }
}
