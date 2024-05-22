using OnlineVideoCourses.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace OnlineVideoCourse.Aplication.DTOs.LessonDTOs;

public class AddLessonDto
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; } = string.Empty;
    [Required(ErrorMessage = "Description is required")]
    public string Description { get; set; } = string.Empty;
    [Required(ErrorMessage = "FilePath is required")]
    public string FilePath { get; set; } = string.Empty;
    [Required(ErrorMessage = "SubjectID is required")]
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
