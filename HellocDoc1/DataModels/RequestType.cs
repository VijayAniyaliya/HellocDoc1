using System;
using System.Collections.Generic;

namespace HellocDoc1.DataModels;

public partial class RequestType
{
    public int RequestTypeId { get; set; }

    public string Name { get; set; } = null!;
}
