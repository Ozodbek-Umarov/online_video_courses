using Microsoft.EntityFrameworkCore;
using OnlineVideoCourses.Data.DbContexts;
using OnlineVideoCourses.Data.Interfaces;
using OnlineVideoCourses.Domain.Entities;

namespace OnlineVideoCourses.Data.Repositories;

public class UserRepository(AppDbContext dbContext) : GenericRepository<User>(dbContext), IUserRepository
{
    public async Task<User?> GetByEmailAsync(string email)
        => await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
}
