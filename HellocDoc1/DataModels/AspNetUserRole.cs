using System;
using System.Collections.Generic;

namespace HellocDoc1.DataModels;

public partial class AspNetUserRole
{
    public string UserId { get; set; } = null!;

    public string RoleId { get; set; } = null!;

    public virtual AspNetUser User { get; set; } = null!;
}
