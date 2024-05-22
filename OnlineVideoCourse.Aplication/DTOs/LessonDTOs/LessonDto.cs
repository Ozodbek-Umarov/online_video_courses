using OnlineVideoCourses.Domain.Entities;

namespace OnlineVideoCourse.Aplication.DTOs.LessonDTOs;

public class LessonDto : AddLessonDto
{
    public int Id { get; set; }
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
