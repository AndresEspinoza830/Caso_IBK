using TokenService.Application.Handlers.Commands.Token.GenerateToken;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TokenService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase    
    {
        private readonly IMediator _mediator;
        public TokenController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("GenerateToken")]
        public async Task<IActionResult> GenerateToken([FromBody] GenerateTokenRequest request)
        {
            var response = await _mediator.Send(request).ConfigureAwait(false);
            return Ok(response);
        }
    }
}
