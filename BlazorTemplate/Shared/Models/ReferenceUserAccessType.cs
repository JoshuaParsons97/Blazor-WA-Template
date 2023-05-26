using System;
using System.Collections.Generic;

namespace BlazorTemplate.Shared.Models;

public partial class ReferenceUserAccessType
{
    public int AccessTypeId { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<LinkUserRole> LinkUserRoles { get; set; } = new List<LinkUserRole>();
}
