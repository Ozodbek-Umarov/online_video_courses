namespace OnlineVideoCourse.Aplication.Interfaces;

public interface IEmailService
{    Task SendMessageAsync(string to, string subject, string message);
}
