using UserModule.UserService.Business.Commands;
using UserModule.UserService.Data.Interfaces;

namespace UserModule.UserService.Business.Handlers
{
    public class RemoveUserCommandHandler
    {
        private readonly IUserRepository userRepository;

        public RemoveUserCommandHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task Handle(RemoveUserCommand command)
        {
            await this.userRepository.DeleteAsync(command.Id);
        }
    }
}