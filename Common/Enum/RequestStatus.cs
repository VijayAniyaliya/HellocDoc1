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
        MdEnRoute =4,
        MdOnSite=5,
        Cuncluded=6,
        CancelledByPatient =7,
        Closed =8,
        Unpaid =9,
        Clear =10,
    }  

    public enum RequestType
    {
        Patient=1,
        FamilyFriend=2,
        Business =3,
        Concierge=4,
    }
}
