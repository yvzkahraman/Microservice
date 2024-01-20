

using MediatR;
using UserModule.UserService.Business.Dtos;

namespace UserModule.UserService.Business.Queries
{
    public class GetUserListQuery : IRequest<List<UserDto>?>
    {

    }
}