using Microsoft.EntityFrameworkCore;
using OnlineVideoCourses.Data.DbContexts;
using OnlineVideoCourses.Data.Interfaces;
using OnlineVideoCourses.Domain.Entities;
using OnlineVideoCourses.Domain.Enums;

namespace Test_NUnit.Data;

public class CategoryRepositoryTest
{
    AppDbContext dbContext;
    IUnitOfWork unitOfWork;

    [SetUp]
    public void Setup()
    {
        dbContext = DbContextHelper.GetDbContext();
        unitOfWork = DbContextHelper.GetUnitOfWork();
    }

    [Test]
    [TestCase("Test2")]
    public async Task AddAsync(string name)
    {
        var category = new Category() { Name = name };

        await unitOfWork.Category.CreateAsync(category);
        var result = await dbContext.Categories.FirstOrDefaultAsync(p => p.Name == name);

        Assert.That(category.Name, Is.EqualTo(result!.Name));
    }

    [Test]
    [TestCase("Test3")]
    public async Task GetCategoryByName(string name)
    {
        var category = new Category() { Name = name };
        await unitOfWork.Category.CreateAsync(category);

        var result = await unitOfWork.Category.GetCategoryByName(name);

        Assert.That(result.Name, Is.EqualTo(category.Name));
    }

    [Test]
    public async Task GetAllAsync()
    {
        var category1 = new Category() { Name = "Test4" };
        var category2 = new Category() { Name = "Test5" };
        await unitOfWork.Category.CreateAsync(category1);
        await unitOfWork.Category.CreateAsync(category2);

        var result = await unitOfWork.Category.GetAllAsync();

        Assert.That(result.Count, Is.EqualTo(2));
    }

    [Test]
    [TestCase("Test6")]
    public async Task GetByIdAsync(string name)
    {
        var category = new Category() { Name = name };
        await unitOfWork.Category.CreateAsync(category);
        int categoryId = category.Id;

        var result = await unitOfWork.Category.GetByIdAsync(categoryId);

        Assert.That(result!.Name, Is.EqualTo(category.Name));
    }

    [Test]
    [TestCase("Test7")]
    public async Task UpdateAsync(string name)
    {
        var category = new Category() { Name = "Initial Name" };
        await unitOfWork.Category.CreateAsync(category);
        int categoryId = category.Id;

        category.Name = name;
        await unitOfWork.Category.UpdateAsync(category);
        var result = await unitOfWork.Category.GetByIdAsync(categoryId);

        Assert.That(result!.Name, Is.EqualTo(name));
    }

    [Test]
    [TestCase("Test8")]
    public async Task DeleteAsync(string name)
    {

        var category = new Category() { Name = name };
        await unitOfWork.Category.CreateAsync(category);
        int categoryId = category.Id;

        await unitOfWork.Category.DeleteAsync(category);
        var result = await unitOfWork.Category.GetByIdAsync(categoryId);

        Assert.IsNull(result);
    }

    [TearDown]
    public void Teardown()
    {
        dbContext.Database.EnsureDeleted();
        dbContext.Dispose();
    }
}
