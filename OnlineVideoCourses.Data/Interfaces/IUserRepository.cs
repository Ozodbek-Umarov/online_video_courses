using OnlineVideoCourses.Domain.Entities;

namespace OnlineVideoCourses.Data.Interfaces;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
}
