using System.Diagnostics.Metrics;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserModule.UserService.Business.Commands;
using UserModule.UserService.Business.Handlers;
using UserModule.UserService.Business.Queries;

namespace UserModule.UserService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IMediator mediator;

        public UsersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.mediator.Send(new GetUserListQuery());

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommand command)
        {
            var result = await this.mediator.Send(command);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateUserCommand command)
        {
            await this.mediator.Send(command);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(string id)
        {
            await this.mediator.Send(new RemoveUserCommand(id));
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await this.mediator.Send(new GetUserQuery(id));
            return Ok(result);
        }


    }
}