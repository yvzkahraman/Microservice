using UserModule.UserService.Business.Dtos;
using UserModule.UserService.Business.Queries;
using UserModule.UserService.Data.Interfaces;

namespace UserModule.UserService.Business.Handlers
{
    public class GetUserListQueryHandler
    {
        private readonly IUserRepository repository;
        public GetUserListQueryHandler(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<UserDto>?> Handle(GetUserListQuery query)
        {
            var result = await this.repository.GetList();

            return result?.Select(x => new UserDto
            {
                FirstName = x.FirstName,
                Id = x.Id,
                LastName = x.LastName,
                Username = x.Username,
            }).ToList();
        }
    }
}