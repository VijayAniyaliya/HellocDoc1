using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enum
{
    public enum PhysicianStatus
    {
        Active = 1,
        NotActive = 2,
        Pending = 3,
    }

    public enum PhysicianOnCallStatus
    {
        UnAvailable = 1,
        Oncall = 2,
        Busy = 3,
    }  
}
