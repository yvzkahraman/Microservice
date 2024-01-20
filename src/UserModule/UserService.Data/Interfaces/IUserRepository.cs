using UserModule.UserService.Data.Entities;

namespace UserModule.UserService.Data.Interfaces
{
    public interface IUserRepository
    {
      Task<AppUser> CreateAsync(AppUser user);
    }
}