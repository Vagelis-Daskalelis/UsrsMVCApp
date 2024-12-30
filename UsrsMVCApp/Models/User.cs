using System;
using System.Collections.Generic;

namespace UsrsMVCApp.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string? Emal { get; set; }

    public string Password { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? Institution { get; set; }

    public string? UserRole { get; set; }

    public virtual Student? Student { get; set; }
}
