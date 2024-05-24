using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using OnlineVideoCourse.Aplication.Common.Exseption;
using OnlineVideoCourse.Aplication.Common.Utils;
using OnlineVideoCourse.Aplication.DTOs.SubjectDTOs;
using OnlineVideoCourse.Aplication.Interfaces;
using OnlineVideoCourses.Data.Interfaces;
using System.Net;
using Microsoft.EntityFrameworkCore;

namespace OnlineVideoCourse.Aplication.Service;

public class SubjectService(IUnitOfWork unitOfWork,
                            IHttpContextAccessor accessor) : ISubjectService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IHttpContextAccessor _accessor = accessor;

    public async Task CreateAsync(SubjectDto subjectDto)
    {
        var existingSubject = await _unitOfWork.Subject.GetAll()
                                                      .FirstOrDefaultAsync(s => s.Name == subjectDto.Name &&
                                                                           s.CategoryId == subjectDto.CategoryId);

        if (existingSubject != null)
        {
            throw new StatusCodeExeption(HttpStatusCode.BadRequest, "A subject with this name already exists in this category.");
        }

        var subject = new OnlineVideoCourses.Domain.Entities.Subject
        {
            Name = subjectDto.Name,
            Description = subjectDto.Description,
            Author = subjectDto.Author,
            CategoryId = subjectDto.CategoryId
        };

        await _unitOfWork.Subject.CreateAsync(subject);
    }

    public async Task DeleteAsync(int id)
    {
        var subject = await _unitOfWork.Subject.GetByIdAsync(id);
        if (subject == null)
        {
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "Subject not found.");
        }

        await _unitOfWork.Subject.DeleteAsync(subject);
    }

    public async Task<IEnumerable<SubjectDto>> GetAllAsync(PaginationParams @params)
    {
        var subjects = _unitOfWork.Subject.GetAll();
        var totalCount = subjects.Count();

        var pagedSubjects = subjects
            .Skip(@params.SkipCount())
            .Take(@params.PageSize)
            .Select(s => new SubjectDto
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                Author = s.Author,
                CategoryId = s.CategoryId
            })
            .ToList();

        var paginationMetaData = new PaginationMetaData(totalCount, @params.PageIndex, @params.PageSize);
        _accessor.HttpContext?.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(paginationMetaData));

        return pagedSubjects;
    }

    public async Task<SubjectDto> GetByIdAsync(int id)
    {
        var subject = await _unitOfWork.Subject.GetByIdAsync(id);
        if (subject == null)
        {
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "Subject not found.");
        }

        return new SubjectDto
        {
            Id = subject.Id,
            Name = subject.Name,
            Description = subject.Description,
            Author = subject.Author,
            CategoryId = subject.CategoryId
        };
    }

    public async Task UpdateAsync(int id, SubjectDto subjectDto)
    {
        var subject = await _unitOfWork.Subject.GetByIdAsync(id);
        if (subject == null)
        {
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "Subject not found.");
        }

        if (subject.Name != subjectDto.Name || subject.CategoryId != subjectDto.CategoryId)
        {
            var existingSubject = await _unitOfWork.Subject.GetAll()
                                                          .FirstOrDefaultAsync(s => s.Id != id &&
                                                                               s.Name == subjectDto.Name &&
                                                                               s.CategoryId == subjectDto.CategoryId);

            if (existingSubject != null)
            {
                throw new StatusCodeExeption(HttpStatusCode.BadRequest, "A subject with this name already exists in this category.");
            }
        }

        subject.Name = subjectDto.Name;
        subject.Description = subjectDto.Description;
        subject.Author = subjectDto.Author;
        subject.CategoryId = subjectDto.CategoryId;

        await _unitOfWork.Subject.UpdateAsync(subject);
    }
}
