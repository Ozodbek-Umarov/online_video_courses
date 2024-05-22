using Microsoft.EntityFrameworkCore;
using OnlineVideoCourses.Domain.Entities;
using OnlineVideoCourses.Domain.Enums;

namespace OnlineVideoCourses.Data.DbContexts;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Subject> Subjects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                FirstName = "Ozodbek",
                LastName = "Umarov",
                Email = "ozodchik.krasavchik@gmail.com",
                Gender = Gender.Male,
                IsVerified = true,
                Password = "186cf774c97b60a1c106ef718d10970a6a06e06bef89553d9ae65d938a886eae",
                Role = Role.Admin
            });
    }
}
