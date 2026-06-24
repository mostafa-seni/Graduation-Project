using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.shared.DTOS
{
    public record UserDetailsRespones(Guid id,string fullName, string picture, string village ,string Region)
    {
    }
}
