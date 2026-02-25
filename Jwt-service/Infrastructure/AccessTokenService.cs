using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Jwt_service.Application;
using Jwt_service.Domain;
using Microsoft.IdentityModel.Tokens;

namespace Jwt_service.Infrastructure;

public class AccessTokenService : IAccessTokenService
{
    public string SignToken(AccessTokenInfo info)
    {
        var issuer =
            Environment.GetEnvironmentVariable("JWT_MICROSERVICE")
            ?? throw new Exception(
                "Jwt microservice endpoint environmental variable not reachable"
            );
        var issuedAt = DateTimeOffset.UtcNow;
        var expirationTime = issuedAt.AddMinutes(10);

        // Adding claims based on RFC 9068.
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Iss, issuer),
            new(JwtRegisteredClaimNames.Exp, expirationTime.ToUnixTimeSeconds().ToString()),
            new(JwtRegisteredClaimNames.Aud, info.audience),
            new(JwtRegisteredClaimNames.Sub, info.subject),
            new(JwtRegisteredClaimNames.Iat, issuedAt.ToUnixTimeSeconds().ToString()),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var secretKey =
            Environment.GetEnvironmentVariable("ACCESS_TOKEN_SECRET_KEY")
            ?? throw new Exception("Access token secret key not set");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(claims: claims, signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
