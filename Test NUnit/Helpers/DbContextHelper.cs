using Microsoft.EntityFrameworkCore;
using OnlineVideoCourses.Data.DbContexts;
using OnlineVideoCourses.Data.Interfaces;
using OnlineVideoCourses.Data.Repositories;

public static class DbContextHelper
{
    private static readonly DbContextOptions<AppDbContext> options =
        new DbContextOptionsBuilder<AppDbContext>()
        .UseInMemoryDatabase(databaseName: "movie-ntv")
        .Options;

    public static AppDbContext GetDbContext()
        => new AppDbContext(options);

    public static IUnitOfWork GetUnitOfWork()
        => new UnitOfWork(GetDbContext());
}
