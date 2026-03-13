using PhotoService.Application.Handlers.Queries.UserController;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace PhotoService.Api.Controllers
{
    [EnableRateLimiting("photoLimiter")]
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase    
    {
        private readonly IMediator _mediator;
        public PhotoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetPhoto(int userId)
        {
            var response = await _mediator.Send(new GetUserPhotoRequest { IdUser = userId }).ConfigureAwait(false);
            return Ok(response);
        }
    }
}
