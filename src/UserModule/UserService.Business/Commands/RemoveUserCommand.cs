using MediatR;

namespace UserModule.UserService.Business.Commands
{
    public class RemoveUserCommand : IRequest
    {
        public string Id { get; set; }

        public RemoveUserCommand(string id)
        {
            Id = id;
        }
    }
}