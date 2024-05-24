using OnlineVideoCourse.Aplication.Common.Utils;
using OnlineVideoCourse.Aplication.DTOs.CategorDTOs;
using OnlineVideoCourse.Aplication.DTOs.UserDTOs;

namespace OnlineVideoCourse.Aplication.Interfaces;

public interface ICategoryService
{
    Task<CategoryDto> GetByIdAsync(int id);
    Task<IEnumerable<CategoryDto>> GetAllAsync(PaginationParams @params);
    Task UpdateAsync(int id, CategoryDto categoryDto);
    Task DeleteAsync(int id);
    Task CreateAsync(CategoryDto categoryDto);
}
