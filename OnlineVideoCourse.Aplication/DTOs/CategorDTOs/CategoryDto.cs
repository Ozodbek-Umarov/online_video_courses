using OnlineVideoCourses.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace OnlineVideoCourse.Aplication.DTOs.CategorDTOs;

public class CategoryDto : AddCategoryDto
{
    [Required(ErrorMessage = "Id is required")]
    public int Id { get; set; }

    public static implicit operator CategoryDto(Category category)
    {
        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name
        };
    }
}
