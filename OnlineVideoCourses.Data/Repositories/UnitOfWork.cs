using OnlineVideoCourses.Data.DbContexts;
using OnlineVideoCourses.Data.Interfaces;

namespace OnlineVideoCourses.Data.Repositories;

public class UnitOfWork(AppDbContext dbContext) : IUnitOfWork
{
    private readonly AppDbContext dbContext = dbContext;

    public ICategoryRepositiry Category => new CategoryRepository(dbContext);

    public ILessonRepository Lesson => new LessonRepository(dbContext);

    public ISubjectRepository Subject => new SubjectRepository(dbContext);

    public IUserRepository User => new UserRepository(dbContext);
}
