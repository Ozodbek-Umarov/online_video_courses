using OnlineVideoCourses.Domain.Entities;

namespace OnlineVideoCourses.Data.Interfaces;

public interface ICategoryRepositiry : IGenericRepository<Category>
{
    Task<Category> GetCategoryByName(string name);
}
