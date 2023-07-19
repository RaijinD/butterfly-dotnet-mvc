using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace butterfly_dotnet_mvc.Controllers;

public struct TokenGenerationRequest
{
    public string email;
    public int userId;
    public string role;

    public TokenGenerationRequest(int userId, string email, string role)
    {
        this.userId = userId;
        this.email = email;
        this.role = role;
    }
}


public class AuthController : ControllerBase
{
    private static readonly TimeSpan tokenLifeTime = TimeSpan.FromHours(4);
    private readonly IConfiguration _config;

    public AuthController(IConfiguration configuration)
    {
        _config = configuration;
    }

    [HttpPost]
    public IActionResult GenerateToken([FromBody]TokenGenerationRequest request)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_config["Jwt:key"]!);

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Sub, request.email),
            new(JwtRegisteredClaimNames.Email, request.email),
            new("userId", request.userId.ToString()),
            new("role", request.role)
        };

        // // https://www.youtube.com/watch?v=mgeuh8k3I4g&t=235s
        // foreach (var claimPair in request.CustomClaims)
        // {
        //     var jsonElement = (JsonElement)claimPair.value;
        //     var valueType = jsonElement.ValueKind switch
        //     {
        //         JsonValueKind.True => ClaimValueTypes.Boolean,
        //         JsonValueKind.False => ClaimValueTypes.Boolean,
        //         JsonValueKind.Number => ClaimValueTypes.Double,
        //         _ => ClaimValueTypes.String
        //     };
        // }
        
        
        var tokenDescriptor = new SecurityTokenDescriptor {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.Add(tokenLifeTime),
            Issuer = "",
            Audience = "",
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),_config["Jwt:key"])
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        var jwt = tokenHandler.WriteToken(token);
        return Ok(jwt);
    }

}
