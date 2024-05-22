using OnlineVideoCourses.Domain.Entities;
using OnlineVideoCourses.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace OnlineVideoCourse.Aplication.DTOs.UserDTOs;

public class UpdateUserDto
{
    [Required(ErrorMessage = "First name is required")]
    public string FirstName { get; set; } = "";
    [Required(ErrorMessage = "Last name is required")]
    public string LastName { get; set; } = "";
    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; } = "";
    public bool IsVerified { get; set; } = false;
    public Gender Gender { get; set; }
    [Required(ErrorMessage = "Password is required")]
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
