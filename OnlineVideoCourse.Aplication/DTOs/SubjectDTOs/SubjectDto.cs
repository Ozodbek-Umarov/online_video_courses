using OnlineVideoCourses.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace OnlineVideoCourse.Aplication.DTOs.SubjectDTOs;

public class SubjectDto : AddSubjectDto
{
    [Required(ErrorMessage = "Id is required")]
    public int Id { get; set; }
    [Required(ErrorMessage = "Name is required")]
    public Category Category { get; set; }

    public static implicit operator SubjectDto(Subject subject)
    {
        return new SubjectDto
        {
            Id = subject.Id,
            Name = subject.Name,
            Author = subject.Author,
            Description = subject.Description,
            CategoryId = subject.CategoryId,
            Category = subject.Category
        };
    }

    public static implicit operator Subject(SubjectDto subjectDto)
    {
        return new Subject
        {
            Id = subjectDto.Id,
            Name = subjectDto.Name,
            Description = subjectDto.Description,
            Author = subjectDto.Author,
            CategoryId = subjectDto.CategoryId,
            Category = subjectDto.Category
        };
    }
}
