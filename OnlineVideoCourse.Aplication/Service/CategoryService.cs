using OnlineVideoCourse.Aplication.Common.Utils;
using OnlineVideoCourse.Aplication.DTOs.CategorDTOs;
using OnlineVideoCourse.Aplication.Interfaces;
using OnlineVideoCourses.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using OnlineVideoCourse.Aplication.Common.Exseption;
using System.Net;
using Newtonsoft.Json;

namespace OnlineVideoCourse.Aplication.Service;

public class CategoryService(IUnitOfWork unitOfWork,
                             IHttpContextAccessor accessor) : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IHttpContextAccessor _accessor = accessor;

    public async Task CreateAsync(CategoryDto categoryDto)
    {
        var existCategory = await _unitOfWork.Category.GetCategoryByName(categoryDto.Name);
        if (existCategory is not null)
            throw new StatusCodeExeption(HttpStatusCode.BadRequest, "This category is already exist");

        var category = new OnlineVideoCourses.Domain.Entities.Category
        {
            Name = categoryDto.Name
        };

        await _unitOfWork.Category.CreateAsync(category);
    }

    public async Task DeleteAsync(int id)
    {
        var category = await _unitOfWork.Category.GetByIdAsync(id);
        if (category is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "Category not found");

        await _unitOfWork.Category.DeleteAsync(category);
    }

    public async Task<IEnumerable<CategoryDto>> GetAllAsync(PaginationParams @params)
    {
        var categories = await _unitOfWork.Category.GetAllAsync();

        var metadata = new PaginationMetaData(categories.Count(), @params.PageIndex, @params.PageSize);
        _accessor.HttpContext?.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

        var pagedCategories = categories
            .Skip(@params.SkipCount())
            .Take(@params.PageSize)
            .Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name
            })
            .ToList();

        return pagedCategories;
    }

    public async Task<CategoryDto> GetByIdAsync(int id)
    {
        var category = await _unitOfWork.Category.GetByIdAsync(id);
        if (category is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "Category not found");

        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name
        };
    }

    public async Task UpdateAsync(int id, CategoryDto categoryDto)
    {
        var category = await _unitOfWork.Category.GetByIdAsync(id);
        if (category is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "Category not found");

        if (categoryDto.Name != category.Name)
        {
            var existCategory = await _unitOfWork.Category.GetCategoryByName(categoryDto.Name);
            if (existCategory is not null)
                throw new StatusCodeExeption(HttpStatusCode.BadRequest, "This category is already exist");
        }

        category.Name = categoryDto.Name;

        await _unitOfWork.Category.UpdateAsync(category);
    }
}
