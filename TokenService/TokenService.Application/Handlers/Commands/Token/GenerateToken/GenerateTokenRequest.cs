using MediatR;
using System.ComponentModel.DataAnnotations;

namespace TokenService.Application.Handlers.Commands.Token.GenerateToken
{
    public class GenerateTokenRequest : IRequest<GenerateTokenResponse>
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
