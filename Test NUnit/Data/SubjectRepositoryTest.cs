using Microsoft.EntityFrameworkCore;
using OnlineVideoCourses.Data.DbContexts;
using OnlineVideoCourses.Data.Interfaces;
using OnlineVideoCourses.Domain.Entities;

namespace Test_NUnit.Data;

public class SubjectRepositoryTest
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
    public async Task AddAsync(string name)
    {
        var category = new Category { Name = "Test Category" };
        await unitOfWork.Category.CreateAsync(category);

        var subject = new Subject { Name = name, CategoryId = category.Id };

        await unitOfWork.Subject.CreateAsync(subject);
        var result = await dbContext.Subjects.FirstOrDefaultAsync(s => s.Name == subject.Name);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Name, Is.EqualTo(subject.Name));
    }

    [Test]
    [TestCase("Test2")]
    public async Task GetSubjectByNameAsync(string name)
    {
        var category = new Category { Name = "Test Category" };
        await unitOfWork.Category.CreateAsync(category);

        var subject = new Subject { Name = name, CategoryId = category.Id };
        await unitOfWork.Subject.CreateAsync(subject);

        var result = await dbContext.Subjects.FirstOrDefaultAsync(s => s.Name == subject.Name);

        Assert.IsNotNull(result);
        Assert.AreEqual(name, result.Name);
    }

    [TearDown]
    public void TearDown()
    {
        dbContext.Database.EnsureDeleted();
        dbContext.Dispose();
    }
}
