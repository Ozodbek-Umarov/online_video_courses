using OnlineVideoCourses.Domain.Entities;

namespace OnlineVideoCourse.Aplication.DTOs.CategorDTOs;

public class AddCategoryDto
{
    public string Name { get; set; } = string.Empty;

    public static implicit operator Category(AddCategoryDto dto)
    {
        return new Category
        {
            Name = dto.Name
        };
    }
}
