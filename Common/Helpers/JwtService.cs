using Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Common.Helpers
{
    public class JwtService
    {
        public static string GetJwtToken(AspNetUser aspnetuser)
        {
            var claims = new List<Claim>
            {
                new Claim("userName", aspnetuser.UserName),
                new Claim(ClaimTypes.Email, aspnetuser.Email??""),
                new Claim(JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString()),
                new Claim("firstname", aspnetuser.Users.FirstOrDefault()?.FirstName??""),
                new Claim("lastname", aspnetuser.Users.FirstOrDefault()?.LastName??""),

            };
            foreach (var role in aspnetuser.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name));
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("UHJHSANIVA787FVGHMJYAERvlkuytnbf"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.UtcNow.AddMinutes(120);

            var token = new JwtSecurityToken(

                "Issuer", "Audience",
                claims,
                expires: expires,
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static bool ValidateToken(string token, out JwtSecurityToken jwtSecurityToken)
        {
            jwtSecurityToken = null;

            if (token == null)
                return false;

            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes("UHJHSANIVA787FVGHMJYAERvlkuytnbf");

            try
            {

                tokenHandler.ValidateToken(token, new TokenValidationParameters

                {

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero

                }, out SecurityToken validatedToken);

                // Corrected access to the validatedToken

                jwtSecurityToken = (JwtSecurityToken)validatedToken;

                if (jwtSecurityToken != null)

                    return true;

                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
