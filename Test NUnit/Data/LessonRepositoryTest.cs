using Microsoft.EntityFrameworkCore;
using OnlineVideoCourses.Data.DbContexts;
using OnlineVideoCourses.Data.Interfaces;
using OnlineVideoCourses.Domain.Entities;

namespace Test_NUnit.Data;

public class LessonRepositoryTest
{
    AppDbContext dbContext;
    IUnitOfWork unitOfWork;

    [SetUp]
    public void SetUp()
    {
        dbContext = DbContextHelper.GetDbContext();
        unitOfWork = DbContextHelper.GetUnitOfWork();
    }

    [Test]
    [TestCase("Test1")]
    public async Task AddAsync(string title)
    {
        var category = new Category { Name = "Test Category" };
        await unitOfWork.Category.CreateAsync(category);

        var subject = new Subject { Name = "Test Subject", CategoryId = category.Id };
        await unitOfWork.Subject.CreateAsync(subject);

        var lesson = new Lesson { Name = title, Description = "Test", FilePath = "akbahd/ajwda"};

        await unitOfWork.Lesson.CreateAsync(lesson);
        var result = await dbContext.Lessons.FirstOrDefaultAsync(p => p.Name == lesson.Name);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Name, Is.EqualTo(lesson.Name));
    }

    [Test]
    [TestCase("Test2")]
    public async Task GetLessonByNameAsync(string title)
    {
        var category = new Category { Name = "Test Category" };
        await unitOfWork.Category.CreateAsync(category);

        var subject = new Subject { Name = "Test Subject", CategoryId = category.Id };
        await unitOfWork.Subject.CreateAsync(subject);

        var lesson = new Lesson { Name = title, Description = "Test", FilePath = "akbahd/ajwda"};
        await unitOfWork.Lesson.CreateAsync(lesson);

        var result = await dbContext.Lessons.FirstOrDefaultAsync(p => p.Name == lesson.Name);

        Assert.IsNotNull(result);
        Assert.AreEqual(title, result.Name);
    }

    [TearDown]
    public void TearDown()
    {
        dbContext.Database.EnsureDeleted();
        dbContext.Dispose();
    }
}
