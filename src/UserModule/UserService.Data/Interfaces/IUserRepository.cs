using UserModule.UserService.Data.Entities;

namespace UserModule.UserService.Data.Interfaces
{
    public interface IUserRepository
    {
      Task<AppUser> CreateAsync(AppUser user);
       Task UpdateAsync(AppUser user);

       Task DeleteAsync(string id);

       Task<List<AppUser>?> GetList();

       Task<AppUser?> FindOne(string id);
    }
}