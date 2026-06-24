using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Contractts
{
    public interface IDbInitializer
    {
        Task InitializeAsync();
      
    }
}
