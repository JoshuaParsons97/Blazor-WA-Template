using System;
using System.Collections.Generic;

namespace BlazorTemplate.Shared.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Email { get; set; } = null!;

    public byte[] Password { get; set; } = null!;

    public byte[]? Salt { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime LastActive { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public virtual ICollection<LinkUserRole> LinkUserRoles { get; set; } = new List<LinkUserRole>();

    public virtual ICollection<PasswordRecovery> PasswordRecoveries { get; set; } = new List<PasswordRecovery>();
}
