using System;
using System.Collections.Generic;
using BCryptNet = BCrypt.Net.BCrypt;

namespace AppEmail.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public void SetPassword(string password)
    {
        Password = BCryptNet.HashPassword(password);
    }

    public bool VerifyPassword(string password)
    {
        return BCryptNet.Verify(password, Password);
    }
}
