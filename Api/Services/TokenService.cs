using Api.Models;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Api.Services;

public class TokenService(string secretKey)
{
    public string GenerateToken(User user)
    {
        SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(secretKey));

        Claim[] claims = new[] {
          new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
          new Claim(JwtRegisteredClaimNames.Email, user.Email),
        };

        JwtSecurityToken token = new(
            claims: claims,
            expires: DateTime.Now.AddMinutes(45)
        );

        string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
        return tokenString;
    }
}
