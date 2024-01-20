using UserModule.UserService.Buiness.Commands;
using UserModule.UserService.Data.Interfaces;

namespace UserModule.UserService.Buiness.Handlers
{
    public class CreateUserCommandHandler
    {
        private readonly IUserRepository repository;

        public CreateUserCommandHandler(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task Handle(CreateUserCommand command)
        {
            // business spesifik


            // validation 
            // business rule
            await this.repository.CreateAsync(new Data.Entities.AppUser
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Password = command.Password,
                Username = command.Username,
            });

        }
    }

}