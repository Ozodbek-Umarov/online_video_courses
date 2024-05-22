using OnlineVideoCourses.Domain.Entities;

namespace OnlineVideoCourse.Aplication.DTOs.LessonDTOs;

public class AddLessonDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string FilePath { get; set; } = string.Empty;

    public int SubjectID { get; set; }

    public static implicit operator Lesson(AddLessonDto lessonDto)
    {
        return new Lesson
        {
            Name = lessonDto.Name,
            Description = lessonDto.Description,
            FilePath = lessonDto.FilePath,
            SubjectID = lessonDto.SubjectID
        };
    }
}
