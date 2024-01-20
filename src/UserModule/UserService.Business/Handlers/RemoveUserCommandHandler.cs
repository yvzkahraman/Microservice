using MediatR;
using UserModule.UserService.Business.Commands;
using UserModule.UserService.Data.Interfaces;

namespace UserModule.UserService.Business.Handlers
{
    public class RemoveUserCommandHandler : IRequestHandler<RemoveUserCommand>
    {
        private readonly IUserRepository userRepository;

        public RemoveUserCommandHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task Handle(RemoveUserCommand request, CancellationToken cancellationToken)
        {
            await this.userRepository.DeleteAsync(request.Id);
        }
    }
}