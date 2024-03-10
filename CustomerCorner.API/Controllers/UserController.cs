using CustomerCorner.Application.Features.Users.Commands.CreateUser;
using CustomerCorner.Application.Features.Users.Queries.GetListUsers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerCorner.API.Controllers
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

        [HttpGet("all" , Name = "GetAllUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<UserListDTO>>> GetAllUsers()
        {
            var result = await _mediator.Send(new GetUserListQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateUserCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }
    }
}
