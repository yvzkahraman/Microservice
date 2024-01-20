using UserModule.UserService.Business.Commands;
using UserModule.UserService.Business.Dtos;
using UserModule.UserService.Data.Interfaces;

namespace UserModule.UserService.Business.Handlers
{
    public class CreateUserCommandHandler
    {
        private readonly IUserRepository repository;

        public CreateUserCommandHandler(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task<UserDto> Handle(CreateUserCommand command)
        {
            var appUser = await this.repository.CreateAsync(new Data.Entities.AppUser
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Password = command.Password,
                Username = command.Username,
            });

            return new UserDto
            {
                Id = appUser.Id,
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
                Username = appUser.Username,
            };

        }
    }

}