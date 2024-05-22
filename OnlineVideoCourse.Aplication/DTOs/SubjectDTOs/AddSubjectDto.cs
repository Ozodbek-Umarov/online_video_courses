using OnlineVideoCourses.Domain.Entities;

namespace OnlineVideoCourse.Aplication.DTOs.SubjectDTOs;

public class AddSubjectDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
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
