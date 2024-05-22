namespace OnlineVideoCourses.Domain.Entities;

public class Subject : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description {  get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;

    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
