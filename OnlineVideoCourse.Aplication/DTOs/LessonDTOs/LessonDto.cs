using OnlineVideoCourses.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace OnlineVideoCourse.Aplication.DTOs.LessonDTOs;

public class LessonDto : AddLessonDto
{
    [Required(ErrorMessage = "Id is required")]
    public int Id { get; set; }
    [Required(ErrorMessage = "Subject is required")]
    public Subject Subject { get; set; }

    public static implicit operator LessonDto(Lesson lesson)
    {
        return new LessonDto
        {
            Id = lesson.Id,
            Name = lesson.Name,
            Description = lesson.Description,
            FilePath = lesson.FilePath,
            SubjectID = lesson.SubjectID,
            Subject = lesson.Subject
        };
    }
}
