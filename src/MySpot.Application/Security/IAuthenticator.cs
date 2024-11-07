using MySpot.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySpot.Application.Security
{
    public interface IAuthenticator
    {
        JwtDto CreateToken(Guid userId, string role);
    }
}
