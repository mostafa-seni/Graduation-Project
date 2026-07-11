using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Entities
{
    public enum UserStatus
    {
        Pending=1,
        Approved=2,
        Rejected=3,
        Suspended=4
    }
}
