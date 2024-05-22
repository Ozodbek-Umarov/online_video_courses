using OnlineVideoCourses.Domain.Entities;

namespace OnlineVideoCourse.Aplication.Interfaces;

public interface IAuthManager
{
    string GeneratedToken(User user);
}
