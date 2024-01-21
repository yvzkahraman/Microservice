
using MediatR;


namespace UserModule.UserService.Business.Commands
{
    public class UpdateUserCommand : IRequest
    {
        public string Id { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}