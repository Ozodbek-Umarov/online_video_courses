using OnlineVideoCourse.Aplication.DTOs.UserDTOs;

namespace OnlineVideoCourse.Aplication.Interfaces;

public interface IUserService
{
    Task<UserDto> GetByIdAsync(int id);
    Task<List<UserDto>> GetAllAsync();
    Task UpdateAsync(int id, UpdateUserDto dto);
    Task DeleteAsync(int id);
}
