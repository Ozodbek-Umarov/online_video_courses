using OnlineVideoCourse.Aplication.Common.Utils;
using OnlineVideoCourse.Aplication.DTOs.LessonDTOs;

namespace OnlineVideoCourse.Aplication.Interfaces;

public interface ILessonService
{
    Task<LessonDto> GetByIdAsync(int id);
    Task<(IEnumerable<LessonDto> Lessons, PaginationMetaData MetaData)> GetAllAsync(PaginationParams @params);
    Task UpdateAsync(int id, LessonDto lessonDto);
    Task DeleteAsync(int id);
    Task CreateAsync(LessonDto lessonDto);
}
