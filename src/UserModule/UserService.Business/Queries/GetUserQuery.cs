using MediatR;
using UserModule.UserService.Business.Dtos;

namespace UserModule.UserService.Business.Queries
{
    public class GetUserQuery : IRequest<UserDto?>
    {
        public string Id { get; set; } = null!;

        public GetUserQuery(string id)
        {
            Id = id;
        }
    }
}