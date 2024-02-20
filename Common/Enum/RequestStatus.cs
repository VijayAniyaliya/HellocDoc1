using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enum
{
    public enum RequestStatus
    {
        Unassigned=1,
        Accepted=2,
        Cancelled =3,
        Reserving=4,
        MdEnRoute =5,
        MdOnSite=6,
        FollowUp=7,
        Closed =8,
        Locked=9,
        Declined=10,
        Consult=11,
        Clear =12,
        CancelledByProvider=13,
        CCUploadedByClient=14,
        CCApprovedByAdmin=15
    }
}
