using OnlineVideoCourses.Data.DbContexts;
using OnlineVideoCourses.Data.Interfaces;
using OnlineVideoCourses.Domain.Entities;

namespace OnlineVideoCourses.Data.Repositories;

public class LessonRepository(AppDbContext dbContext) : GenericRepository<Lesson>(dbContext), ILessonRepository
{
}
