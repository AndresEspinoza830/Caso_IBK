using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TokenService.Application.Handlers.Commands.Token.GenerateToken
{
    public class GenerateTokenHandler(IConfiguration _configuration) : IRequestHandler<GenerateTokenRequest, GenerateTokenResponse>
    {
        public async Task<GenerateTokenResponse> Handle(GenerateTokenRequest request, CancellationToken cancellationToken)
        {
            if (request.Username != "admin" || request.Password != "caso_ibk_123")
                throw new UnauthorizedAccessException("Invalid credentials");

            var tokenHandler = new JwtSecurityTokenHandler();
            var secretKey = _configuration.GetValue<string>("Jwt:Key") ?? "";
            var issuer = _configuration.GetValue<string>("Jwt:Issuer") ?? "";
            var audience = _configuration.GetValue<string>("Jwt:Audience") ?? "";

            var key = Encoding.UTF8.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, request.Username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new GenerateTokenResponse
            {
                Token = tokenHandler.WriteToken(token)
            };
        }
    }
}
