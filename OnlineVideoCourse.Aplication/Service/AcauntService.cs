using FluentValidation;
using Microsoft.Extensions.Caching.Memory;
using OnlineVideoCourse.Aplication.DTOs.UserDTOs;
using OnlineVideoCourse.Aplication.Interfaces;
using OnlineVideoCourses.Data.Interfaces;

namespace OnlineVideoCourse.Aplication.Service;

public class AcauntService(IUnitOfWork unitOfWork,
                           IAuthManager authManager,
                           IValidator validator,
                           IMemoryCache cache,
                           IEmailService emailService) : IAcauntService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IAuthManager _authManager = authManager;
    private readonly IValidator _validator = validator;
    private readonly IMemoryCache _cache = cache;
    private readonly IEmailService _emailService = emailService;

    public Task<bool> CheckCodeAsync(string email, string code)
    {
        throw new NotImplementedException();
    }

    public Task<string> LoginAsync(LogingDto login)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RegistrAsync(AddUserDto dto)
    {
        throw new NotImplementedException();
    }

    public Task SendCodeAsync(string email)
    {
        throw new NotImplementedException();
    }
}
