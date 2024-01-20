using MediatR;
using UserModule.UserService.Business.Dtos;
using UserModule.UserService.Business.Queries;
using UserModule.UserService.Data.Interfaces;

namespace UserModule.UserService.Business.Handlers
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto?>
    {
        private readonly IUserRepository userRepository;

        public GetUserQueryHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }


        public async Task<UserDto?> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
             var result = await this.userRepository.FindOne(request.Id);
            if (result != null)
            {
                return new UserDto
                {
                    FirstName = result.FirstName,
                    Id = result.Id,
                    LastName = result.LastName,
                    Username = result.Username,

                };
            }
            return null;
        }
    }
}