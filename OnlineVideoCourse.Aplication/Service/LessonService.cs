using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OnlineVideoCourse.Aplication.Common.Exseption;
using OnlineVideoCourse.Aplication.Common.Utils;
using OnlineVideoCourse.Aplication.DTOs.LessonDTOs;
using OnlineVideoCourse.Aplication.Interfaces;
using OnlineVideoCourses.Data.Interfaces;
using System.Net;

namespace OnlineVideoCourse.Aplication.Service;

public class LessonService(IUnitOfWork unitOfWork,
                           IHttpContextAccessor accessor) : ILessonService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IHttpContextAccessor _accessor = accessor;

    public async Task CreateAsync(LessonDto lessonDto)
    {
        var existingLesson = await _unitOfWork.Lesson.GetAll()
                                                    .FirstOrDefaultAsync(l => l.Name == lessonDto.Name &&
                                                                         l.SubjectID == lessonDto.SubjectID);

        if (existingLesson != null)
        {
            throw new StatusCodeExeption(HttpStatusCode.BadRequest, "A lesson with this name already exists in this subject.");
        }

        var lesson = new OnlineVideoCourses.Domain.Entities.Lesson
        {
            Name = lessonDto.Name,
            Description = lessonDto.Description,
            FilePath = lessonDto.FilePath,
            SubjectID = lessonDto.SubjectID
        };

        await _unitOfWork.Lesson.CreateAsync(lesson);
    }

    public async Task DeleteAsync(int id)
    {
        var lesson = await _unitOfWork.Lesson.GetByIdAsync(id);
        if (lesson == null)
        {
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "Lesson not found.");
        }

        await _unitOfWork.Lesson.DeleteAsync(lesson);
    }

    public async Task<(IEnumerable<LessonDto> Lessons, PaginationMetaData MetaData)> GetAllAsync(PaginationParams @params)
    {
        var lessons = _unitOfWork.Lesson.GetAll();

        var totalCount = await lessons.CountAsync();

        var pagedLessons = await lessons
            .Skip(@params.SkipCount())
            .Take(@params.PageSize)
            .Select(l => new LessonDto
            {
                Id = l.Id,
                Name = l.Name,
                Description = l.Description,
                FilePath = l.FilePath,
                SubjectID = l.SubjectID
            })
            .ToListAsync();

        var paginationMetaData = new PaginationMetaData(totalCount, @params.PageIndex, @params.PageSize);
        _accessor.HttpContext?.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(paginationMetaData));

        return (pagedLessons, paginationMetaData);
    }

    public async Task<LessonDto> GetByIdAsync(int id)
    {
        var lesson = await _unitOfWork.Lesson.GetByIdAsync(id);
        if (lesson == null)
        {
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "Lesson not found.");
        }

        return new LessonDto
        {
            Id = lesson.Id,
            Name = lesson.Name,
            Description = lesson.Description,
            FilePath = lesson.FilePath,
            SubjectID = lesson.SubjectID
        };
    }

    public async Task UpdateAsync(int id, LessonDto lessonDto)
    {
        var lesson = await _unitOfWork.Lesson.GetByIdAsync(id);
        if (lesson == null)
        {
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "Lesson not found.");
        }

        if (lesson.Name != lessonDto.Name || lesson.SubjectID != lessonDto.SubjectID)
        {
            var existingLesson = await _unitOfWork.Lesson.GetAll()
                                                        .FirstOrDefaultAsync(l => l.Id != id &&
                                                                             l.Name == lessonDto.Name &&
                                                                             l.SubjectID == lessonDto.SubjectID);

            if (existingLesson != null)
            {
                throw new StatusCodeExeption(HttpStatusCode.BadRequest, "A lesson with this name already exists in this subject.");
            }
        }

        lesson.Name = lessonDto.Name;
        lesson.Description = lessonDto.Description;
        lesson.FilePath = lessonDto.FilePath;
        lesson.SubjectID = lessonDto.SubjectID;

        await _unitOfWork.Lesson.UpdateAsync(lesson);
    }
}
