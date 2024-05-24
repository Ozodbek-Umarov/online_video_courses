using FluentValidation;
using OnlineVideoCourse.Aplication.Common.Validators;
using OnlineVideoCourse.Aplication.DTOs.LessonDTOs;
using OnlineVideoCourse.Aplication.Interfaces;
using OnlineVideoCourses.Data.Interfaces;
using OnlineVideoCourses.Domain.Entities;

namespace OnlineVideoCourse.Aplication.Service;

public class LessonService(IUnitOfWork unitOfWork,
                           IValidator<Lesson> validator) : ILessonService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IValidator<Lesson> _validator = validator;

    public async Task<Lesson> AddAsync(AddLessonDto dto)
    {
        var lesson = await _unitOfWork.Lesson.GetByIdAsync();
    }

    public Task<Lesson> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable<Lesson>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Lesson> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Lesson> UpdateAsync(LessonDto dto)
    {
        throw new NotImplementedException();
    }
}
