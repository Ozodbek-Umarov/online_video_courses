using Microsoft.EntityFrameworkCore;
using OnlineVideoCourses.Data.DbContexts;
using OnlineVideoCourses.Data.Interfaces;
using OnlineVideoCourses.Domain.Entities;

namespace OnlineVideoCourses.Data.Repositories;

public class CategoryRepository(AppDbContext dbContext) : GenericRepository<Category>(dbContext), ICategoryRepositiry
{
    public async Task<Category> GetCategoryByName(string name)
    {
        var category = await _dbContext.Categories.ToListAsync();
        return category.Where(s => s.Name.ToLower().Contains(name.ToLower())).ToList()[0];
    }
}
