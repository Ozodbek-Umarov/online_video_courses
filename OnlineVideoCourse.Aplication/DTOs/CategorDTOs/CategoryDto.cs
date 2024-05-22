using OnlineVideoCourses.Domain.Entities;

namespace OnlineVideoCourse.Aplication.DTOs.CategorDTOs;

public class CategoryDto : AddCategoryDto
{
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
