﻿namespace Lab2.Models;

public class User
{
    public int UserId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string UserSurname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int RoleId { get; set; }
    public Role Role { get; set; } = null!;
    public string Password { get; set; } = string.Empty;
}