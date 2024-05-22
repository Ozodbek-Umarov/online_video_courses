namespace OnlineVideoCourses.Data.Interfaces;

public interface IUnitOfWork
{
    ICategoryRepositiry Category { get; }
    ILessonRepository Lesson { get; }
    ISubjectRepository Subject { get; }
    IUserRepository User { get; }
}
