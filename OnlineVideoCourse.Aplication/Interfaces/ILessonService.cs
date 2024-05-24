using OnlineVideoCourse.Aplication.DTOs.LessonDTOs;
using OnlineVideoCourses.Domain.Entities;

namespace OnlineVideoCourse.Aplication.Interfaces;

public interface ILessonService
{
    Task<Lesson> GetByIdAsync(int id);
    Task<IQueryable<Lesson>> GetAllAsync();
    Task<Lesson> AddAsync(AddLessonDto dto);
    Task<Lesson> UpdateAsync(LessonDto dto);
    Task<Lesson> DeleteAsync(int id);
}
