using OnlineVideoCourses.Data.DbContexts;
using OnlineVideoCourses.Data.Interfaces;
using OnlineVideoCourses.Domain.Entities;

namespace OnlineVideoCourses.Data.Repositories;

public class SubjectRepository(AppDbContext dbContext) : GenericRepository<Subject>(dbContext), ISubjectRepository
{
}
