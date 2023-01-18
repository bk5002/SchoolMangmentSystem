using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApplication10.Utilites
{
    public class JWTToken
    {
        public string GetToken(string id, string Role) {
            var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Enums.SecretKey));
            var Cridantial = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>();
            claims.Add(new Claim(Enums.Id,id));
            claims.Add(new Claim(Enums.MyRole, Role));

            var token = new JwtSecurityToken(
                signingCredentials: Cridantial,
                claims: claims,
                expires: DateTime.Now.AddDays(1)
                );

            return  new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
