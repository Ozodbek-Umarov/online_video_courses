﻿using OnlineVideoCourses.Domain.Enums;

namespace OnlineVideoCourses.Domain.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";
    public bool IsVerified { get; set; } = false;
    public Gender Gender { get; set; }
    public string Password { get; set; } = "";
    public Role Role { get; set; } = Role.User;
}
