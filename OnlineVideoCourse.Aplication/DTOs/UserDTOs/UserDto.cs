using OnlineVideoCourses.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace OnlineVideoCourse.Aplication.DTOs.UserDTOs;

public class UserDto : AddUserDto
{
    [Required(ErrorMessage = "id name is required")]
    public int Id { get; set; }

    public static implicit operator UserDto(User user)
    {
        return new UserDto
        {
            Id = user.Id,
            LastName = user.LastName,
            FirstName = user.FirstName,
            Email = user.Email,
            Gender = user.Gender,
            Password = user.Password,
            Role = user.Role
        };
    }
}
