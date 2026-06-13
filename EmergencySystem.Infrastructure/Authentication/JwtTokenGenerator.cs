using EmergencySystem.Application.DTOs.Authentication;
using EmergencySystem.Application.Interfaces;
using EmergencySystem.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace EmergencySystem.Infrastructure.Authentication;

public sealed class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtSettings _jwtSettings;

    public JwtTokenGenerator(IOptions<JwtSettings> options)
    {
        _jwtSettings = options.Value;
    }

    public GenerateTokenResult GenerateToken(User user)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
        var tokenHandler = new JwtSecurityTokenHandler();
        var expiresAt = DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new System.Security.Claims.ClaimsIdentity(new[]
            {
                new System.Security.Claims.Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new System.Security.Claims.Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                new System.Security.Claims.Claim(JwtRegisteredClaimNames.Email, user.Email),
                new System.Security.Claims.Claim("role", user.Role.ToString())
            }),
            Expires = expiresAt,
            Issuer = _jwtSettings.Issuer,
            Audience = _jwtSettings.Audience,
            SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return new GenerateTokenResult(tokenHandler.WriteToken(token), expiresAt);
    }
}
