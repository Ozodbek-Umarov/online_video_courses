using OnlineVideoCourse.Aplication.Common.Exseption;
using OnlineVideoCourse.Aplication.Common.Helper;
using OnlineVideoCourse.Aplication.DTOs.UserDTOs;
using OnlineVideoCourse.Aplication.Interfaces;
using OnlineVideoCourses.Data.Interfaces;
using OnlineVideoCourses.Domain.Entities;
using System.Net;

namespace OnlineVideoCourse.Aplication.Service;

public class UserService(IUnitOfWork unitOfWork) : IUserService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task DeleteAsync(int id)
    {
        var user = await _unitOfWork.User.GetByIdAsync(id);
        if (user is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "User not found");
        await _unitOfWork.User.DeleteAsync(user);
        throw new StatusCodeExeption(HttpStatusCode.OK, "User has been deleted sucessfully");
    }

    public async Task<List<UserDto>> GetAllAsync()
    {
        var users = await _unitOfWork.User.GetAllAsync();
        return users.Select(x => (UserDto)x).ToList();
    }

    public async Task<UserDto> GetByIdAsync(int id)
    {
        var user = await _unitOfWork.User.GetByIdAsync(id);
        if (user is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "User not found");
        return (UserDto)user;
    }

    public async Task UpdateAsync(int id, UpdateUserDto dto)
    {
        var model = await _unitOfWork.User.GetByIdAsync(id);
        if (model is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "User not found");

        var user = (User)dto;
        user.Id = id;
        user.CreatedDate = TimeHelper.GetCurrentTime();
        user.Password = model.Password;

        user.FirstName = dto.FirstName;
        user.LastName = dto.LastName;
        user.Email = dto.Email;
        user.Gender = dto.Gender;

        user.Role = model.Role;

        await _unitOfWork.User.UpdateAsync(user);
        throw new StatusCodeExeption(HttpStatusCode.OK, "User has been updated sucessfully");
    }
}
