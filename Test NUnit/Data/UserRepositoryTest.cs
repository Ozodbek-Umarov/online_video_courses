using Microsoft.EntityFrameworkCore;
using OnlineVideoCourses.Data.DbContexts;
using OnlineVideoCourses.Data.Interfaces;
using OnlineVideoCourses.Domain.Entities;
using OnlineVideoCourses.Domain.Enums;

namespace Test_NUnit.Data;

public class UserRepositoryTest
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
    public async Task AddAsync()
    {
        var user = new User
        {
            FirstName = "Test",
            LastName = "User",
            Email = "test@example.com",
            Password = "hashed_password",
            Role = Role.User
        };

        await unitOfWork.User.CreateAsync(user);
        var result = await dbContext.Users.FirstOrDefaultAsync(u => u.Email == user.Email);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Email, Is.EqualTo(user.Email));
    }

    [Test]
    public async Task GetByEmailAsync()
    {
        var user = new User
        {
            FirstName = "Test",
            LastName = "User",
            Email = "getbyemail@example.com",
            Password = "hashed_password",
            Role = Role.User
        };
        await unitOfWork.User.CreateAsync(user);

        var result = await unitOfWork.User.GetByEmailAsync(user.Email);

        Assert.IsNotNull(result);
        Assert.AreEqual(user.Email, result.Email);
    }


    [TearDown]
    public void TearDown()
    {
        dbContext.Database.EnsureDeleted();
        dbContext.Dispose();
    }
}
