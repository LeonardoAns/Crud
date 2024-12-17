using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Crud.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Crud.Infrastructure.Security.Tokens;

public class AccessTokenGenerator : IAccessTokenGenerator {

    private readonly uint _expirationTimeMinutes;
    private readonly string _signingKey;

    public AccessTokenGenerator(uint expirationTimeMinutes, string signingKey){
        _expirationTimeMinutes = expirationTimeMinutes;
        _signingKey = signingKey;
    }

    public string GenerateToken(User user){
        var claims = new List<Claim>() {
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Sid, user.Identifier.ToString())
        };
        
        var tokenDescriptor = new SecurityTokenDescriptor{
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(_expirationTimeMinutes),
            SigningCredentials = new SigningCredentials(SecurityKey(), SecurityAlgorithms.HmacSha256Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(securityToken);
    }

    private SymmetricSecurityKey SecurityKey(){
        var key = Encoding.UTF8.GetBytes(_signingKey);
        return new SymmetricSecurityKey(key);
    }
}