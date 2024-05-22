using OnlineVideoCourses.Domain.Entities;
using OnlineVideoCourses.Domain.Enums;
using System.Data;
using System.Reflection;

namespace OnlineVideoCourse.Aplication.DTOs.UserDTOs;

public class AddUserDto
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";
    public bool IsVerified { get; set; } = false;
    public Gender Gender { get; set; }
    public string Password { get; set; } = "";
    public Role Role { get; set; } = Role.User;

    public static implicit operator User(AddUserDto dto)
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
