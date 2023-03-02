using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace ESchoolApi.Models;

public class JWTManagerRepository : IJWTManagerRepository
{
    private readonly IConfiguration iconfiguration;
    
    public JWTManagerRepository(IConfiguration iconfiguration)
    {
        this.iconfiguration = iconfiguration;
    }
    public Token Authenticate(User users)
    {
        // if (!UsersRecords.Any(x => x.Key == users.Name && x.Value == users.Password)) {
        //     return null;
        // } get the user from db

        // Else we generate JSON Web Token
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.UTF8.GetBytes(iconfiguration["JWT:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, users.Name)                    
            }),
            Expires = DateTime.UtcNow.AddHours(4),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return new Token { TokenIdentity = tokenHandler.WriteToken(token) };
    }
}