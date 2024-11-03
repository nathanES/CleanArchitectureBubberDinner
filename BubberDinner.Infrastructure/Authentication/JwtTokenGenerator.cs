using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BubberDinner.Application.Common.Interfaces.Authentication;
using BubberDinner.Application.Common.Interfaces.Services;
using BubberDinner.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace BubberDinner.Infrastructure.Authentication;

public class JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> settings) : IJwtTokenGenerator
{
    public string GenerateToken(User user)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(settings.Value.Secret)),
            SecurityAlgorithms.HmacSha256);
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };
        var securityToken = new JwtSecurityToken(
            issuer: settings.Value.Issuer,
            audience: settings.Value.Audience,
            expires: dateTimeProvider.Now.AddMinutes(settings.Value.ExpiryMinutes),
            claims: claims,
            signingCredentials: signingCredentials);
        
        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}