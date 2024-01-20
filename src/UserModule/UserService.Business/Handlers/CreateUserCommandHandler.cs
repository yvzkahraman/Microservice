using MediatR;
using UserModule.UserService.Business.Commands;
using UserModule.UserService.Business.Dtos;
using UserModule.UserService.Data.Interfaces;

namespace UserModule.UserService.Business.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly IUserRepository repository;

        public CreateUserCommandHandler(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var appUser = await this.repository.CreateAsync(new Data.Entities.AppUser
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Password = request.Password,
                Username = request.Username,
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