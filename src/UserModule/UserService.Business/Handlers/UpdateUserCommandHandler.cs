using MediatR;
using UserModule.UserService.Business.Commands;
using UserModule.UserService.Data.Interfaces;

namespace UserModule.UserService.Business.Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUserRepository userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        
        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            await this.userRepository.UpdateAsync(new Data.Entities.AppUser
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Password = request.Password,
                Username = request.Username,
            });
        }
    }
}