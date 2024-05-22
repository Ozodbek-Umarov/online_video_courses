using OnlineVideoCourses.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace OnlineVideoCourse.Aplication.DTOs.CategorDTOs;

public class AddCategoryDto
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; } = string.Empty;

    public static implicit operator Category(AddCategoryDto dto)
    {
        return new Category
        {
            Name = dto.Name
        };
    }
}
