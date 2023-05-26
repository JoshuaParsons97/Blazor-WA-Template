using System;
using System.Collections.Generic;

namespace BlazorTemplate.Shared.Models;

public partial class ReferenceUserRole
{
    public int RoleId { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<LinkUserRole> LinkUserRoles { get; set; } = new List<LinkUserRole>();
}
