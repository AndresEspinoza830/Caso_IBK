using UserService.Application.Handlers.Queries.UserController;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace UserService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase    
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var response = await _mediator.Send(new GetUserRequest { IdUser =id}).ConfigureAwait(false);
            return Ok(response);
        }
    }
}
