using Data.Entity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IJwtService
    {
        string GetJwtToken(AspNetUser aspnetuser);

        bool ValidateToken(string token, out JwtSecurityToken jwtSecurityToken);
    }
}