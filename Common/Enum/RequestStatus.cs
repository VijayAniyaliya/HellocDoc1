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
        Unassigned = 1,
        Accepted = 2,
        Cancelled = 3,
        MdEnRoute = 4,
        MdOnSite = 5,
        Concluded = 6,
        CancelledByPatient = 7,
        Closed = 8,
        Unpaid = 9,
        Clear = 10,
        Blocked = 11,
    }

    public enum RequestType
    {
        Patient = 1,
        FamilyFriend = 2,
        Business = 3,
        Concierge = 4,
    }

    public enum Month
    {
        Jan = 1,
        Feb = 2,
        Mar = 3,
        Apr = 4,
        May = 5,
        Jun = 6,
        Jul = 7,
        Aug = 8,
        Sep = 9,
        Oct = 10,
        Nov = 11,
        Dec = 12
    }

    public enum Regions
    {
        rajkot = 1,
        snagar = 2,
        surat = 3,
    }
}
