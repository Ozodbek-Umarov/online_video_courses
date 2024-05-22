using OnlineVideoCourses.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace OnlineVideoCourse.Aplication.DTOs.SubjectDTOs;

public class AddSubjectDto
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; } = string.Empty;
    [Required(ErrorMessage = "Description is required")]
    public string Description { get; set; } = string.Empty;
    [Required(ErrorMessage = "Author is required")]
    public string Author { get; set; } = string.Empty;

    public int CategoryId { get; set; }

    public static implicit operator Subject(AddSubjectDto dto)
    {
        return new Subject
        {
            Name = dto.Name,
            Description = dto.Description,
            Author = dto.Author,
            CategoryId = dto.CategoryId
        };
    }
}
