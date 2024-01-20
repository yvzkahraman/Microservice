using System.Diagnostics.Metrics;
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
        private readonly CreateUserCommandHandler createUserCommandHandler;
        private readonly GetUserListQueryHandler getUserListQueryHandler;
        private readonly UpdateUserCommandHandler updateUserCommandHandler;
        private readonly RemoveUserCommandHandler removeUserCommandHandler;

        public UsersController(CreateUserCommandHandler createUserCommandHandler, GetUserListQueryHandler getUserListQueryHandler, UpdateUserCommandHandler updateUserCommandHandler, RemoveUserCommandHandler removeUserCommandHandler)
        {
            this.createUserCommandHandler = createUserCommandHandler;
            this.getUserListQueryHandler = getUserListQueryHandler;
            this.updateUserCommandHandler = updateUserCommandHandler;
            this.removeUserCommandHandler = removeUserCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.getUserListQueryHandler.Handle(new GetUserListQuery());

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommand command)
        {
            var result = await this.createUserCommandHandler.Handle(command);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateUserCommand command)
        {
            await this.updateUserCommandHandler.Handle(command);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(string id)
        {
            await this.removeUserCommandHandler.Handle(new RemoveUserCommand(id));
            return NoContent();
        }


    }
}