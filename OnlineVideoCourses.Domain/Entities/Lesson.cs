namespace OnlineVideoCourses.Domain.Entities;

public class Lesson : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public int SubjectID { get; set; }
    public Subject Subject { get; set; }
}
