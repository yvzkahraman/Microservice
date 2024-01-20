using UserModule.UserService.Business.Commands;
using UserModule.UserService.Data.Interfaces;

namespace UserModule.UserService.Business.Handlers
{
    public class UpdateUserCommandHandler
    {
        private readonly IUserRepository userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }


        public async Task Handle(UpdateUserCommand command)
        {
            await this.userRepository.UpdateAsync(new Data.Entities.AppUser
            {
                Id = command.Id,
                FirstName = command.FirstName,
                LastName = command.LastName,
                Password = command.Password,
                Username = command.Username,
            });
        }
    }
}