using OnlineVideoCourse.Aplication.DTOs.UserDTOs;

namespace OnlineVideoCourse.Aplication.Interfaces;

public interface IAcauntService
{
    Task<bool> RegistrAsync(AddUserDto dto);
    Task<string> LoginAsync(LogingDto login);
    Task SendCodeAsync(string email);
    Task<bool> CheckCodeAsync(string email, string code);
}
